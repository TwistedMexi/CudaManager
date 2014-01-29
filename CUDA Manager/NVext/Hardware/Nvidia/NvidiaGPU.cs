using System;
using System.Globalization;
using System.Text;
using System.IO;
using CUDA_Manager.NVext.Hardware;

namespace CUDA_Manager.NVext.Hardware.Nvidia {
  internal class NvidiaGPU : Hardware {

    private readonly int adapterIndex;
    private readonly NvPhysicalGpuHandle handle;
    private readonly NvDisplayHandle? displayHandle;

    private readonly Sensor[] temperatures;
    private readonly Sensor fan;
    private readonly Sensor[] clocks;
    private readonly Sensor[] loads;
    private readonly Sensor control;
    private readonly Sensor memoryLoad;
    private readonly Control fanControl;

    private bool restoreDefaultFanSpeedRequired;
    private NvLevel initialFanSpeedValue;

    public NvidiaGPU(int adapterIndex, NvPhysicalGpuHandle handle,
      NvDisplayHandle? displayHandle)
      : base(GetName(handle), new Identifier("nvidiagpu",
          adapterIndex.ToString(CultureInfo.InvariantCulture))) {
      this.adapterIndex = adapterIndex;
      this.handle = handle;
      this.displayHandle = displayHandle;

      NvGPUThermalSettings thermalSettings = GetThermalSettings();
      temperatures = new Sensor[thermalSettings.Count];
      for (int i = 0; i < temperatures.Length; i++) {
        NvSensor sensor = thermalSettings.Sensor[i];
        string name;
        switch (sensor.Target) {
          case NvThermalTarget.BOARD: name = "GPU Board"; break;
          case NvThermalTarget.GPU: name = "GPU Core"; break;
          case NvThermalTarget.MEMORY: name = "GPU Memory"; break;
          case NvThermalTarget.POWER_SUPPLY: name = "GPU Power Supply"; break;
          case NvThermalTarget.UNKNOWN: name = "GPU Unknown"; break;
          default: name = "GPU"; break;
        }
        temperatures[i] = new Sensor(name, i, SensorType.Temperature, this,
          new ParameterDescription[0]);
        ActivateSensor(temperatures[i]);
      }

      int value;
      if (NVAPI.NvAPI_GPU_GetTachReading != null &&
        NVAPI.NvAPI_GPU_GetTachReading(handle, out value) == NvStatus.OK) {
        if (value > 0) {
          fan = new Sensor("GPU", 0, SensorType.Fan, this);
          ActivateSensor(fan);
        }
      }

      clocks = new Sensor[3];
      clocks[0] = new Sensor("GPU Core", 0, SensorType.Clock, this);
      clocks[1] = new Sensor("GPU Memory", 1, SensorType.Clock, this);
      clocks[2] = new Sensor("GPU Shader", 2, SensorType.Clock, this);
      for (int i = 0; i < clocks.Length; i++)
        ActivateSensor(clocks[i]);

      loads = new Sensor[3];
      loads[0] = new Sensor("GPU Core", 0, SensorType.Load, this);
      loads[1] = new Sensor("GPU Memory Controller", 1, SensorType.Load, this);
      loads[2] = new Sensor("GPU Video Engine", 2, SensorType.Load, this);
      memoryLoad = new Sensor("GPU Memory", 3, SensorType.Load, this);

      control = new Sensor("GPU Fan", 0, SensorType.Control, this);

      NvGPUCoolerSettings coolerSettings = GetCoolerSettings();
      if (coolerSettings.Count > 0) {
        fanControl = new Control(control,
          coolerSettings.Cooler[0].DefaultMin, 
          coolerSettings.Cooler[0].DefaultMax, coolerSettings.Cooler[0].CurrentPolicy, coolerSettings.Cooler[0].CurrentLevel);
        fanControl.ControlModeChanged += ControlModeChanged;
        fanControl.SoftwareControlValueChanged += SoftwareControlValueChanged;
        ControlModeChanged(fanControl);
        control.Control = fanControl;
      }
      Update();
    }

    private static string GetName(NvPhysicalGpuHandle handle) {
      string gpuName;
      if (NVAPI.NvAPI_GPU_GetFullName(handle, out gpuName) == NvStatus.OK) {
        return "NVIDIA " + gpuName.Trim();
      } else {
        return "NVIDIA";
      }
    }

    public override HardwareType HardwareType {
      get { return HardwareType.GpuNvidia; }
    }

    private NvGPUThermalSettings GetThermalSettings() {
      NvGPUThermalSettings settings = new NvGPUThermalSettings();
      settings.Version = NVAPI.GPU_THERMAL_SETTINGS_VER;
      settings.Count = NVAPI.MAX_THERMAL_SENSORS_PER_GPU;
      settings.Sensor = new NvSensor[NVAPI.MAX_THERMAL_SENSORS_PER_GPU];
      if (!(NVAPI.NvAPI_GPU_GetThermalSettings != null &&
        NVAPI.NvAPI_GPU_GetThermalSettings(handle, (int)NvThermalTarget.ALL,
          ref settings) == NvStatus.OK)) 
      {
        settings.Count = 0;
      }       
      return settings;    
    }

    private NvGPUCoolerSettings GetCoolerSettings() {
      NvGPUCoolerSettings settings = new NvGPUCoolerSettings();
      settings.Version = NVAPI.GPU_COOLER_SETTINGS_VER;
      settings.Cooler = new NvCooler[NVAPI.MAX_COOLER_PER_GPU];
      if (!(NVAPI.NvAPI_GPU_GetCoolerSettings != null &&
        NVAPI.NvAPI_GPU_GetCoolerSettings(handle, 0, 
          ref settings) == NvStatus.OK)) 
      {
        settings.Count = 0;
      }
      return settings;  
    }

    private uint[] GetClocks() {
      NvClocks allClocks = new NvClocks();
      allClocks.Version = NVAPI.GPU_CLOCKS_VER;
      allClocks.Clock = new uint[NVAPI.MAX_CLOCKS_PER_GPU];
      if (NVAPI.NvAPI_GPU_GetAllClocks != null &&
        NVAPI.NvAPI_GPU_GetAllClocks(handle, ref allClocks) == NvStatus.OK) {
        return allClocks.Clock;
      }
      return null;
    }

    public override void Update() {
      NvGPUThermalSettings settings = GetThermalSettings();
      foreach (Sensor sensor in temperatures)
        sensor.Value = settings.Sensor[sensor.Index].CurrentTemp;

      if (fan != null) {
        int value = 0;
        NVAPI.NvAPI_GPU_GetTachReading(handle, out value);
        fan.Value = value;
      }

      uint[] values = GetClocks();
      if (values != null) {
        clocks[0].Value = 0.001f * values[0];
        clocks[1].Value = 0.001f * values[8];
        clocks[2].Value = 0.001f * values[14];
        if (values[30] != 0) {
          clocks[0].Value = 0.0005f * values[30];
          clocks[2].Value = 0.001f * values[30];
        }
      }

      NvPStates states = new NvPStates();
      states.Version = NVAPI.GPU_PSTATES_VER;
      states.PStates = new NvPState[NVAPI.MAX_PSTATES_PER_GPU];
      if (NVAPI.NvAPI_GPU_GetPStates != null &&
        NVAPI.NvAPI_GPU_GetPStates(handle, ref states) == NvStatus.OK) {
        for (int i = 0; i < 3; i++)
          if (states.PStates[i].Present) {
            loads[i].Value = states.PStates[i].Percentage;
            ActivateSensor(loads[i]);
          }
      } else {
        NvUsages usages = new NvUsages();
        usages.Version = NVAPI.GPU_USAGES_VER;
        usages.Usage = new uint[NVAPI.MAX_USAGES_PER_GPU];
        if (NVAPI.NvAPI_GPU_GetUsages != null &&
          NVAPI.NvAPI_GPU_GetUsages(handle, ref usages) == NvStatus.OK) {
          loads[0].Value = usages.Usage[2];
          loads[1].Value = usages.Usage[6];
          loads[2].Value = usages.Usage[10];
          for (int i = 0; i < 3; i++)
            ActivateSensor(loads[i]);
        }
      }


      NvGPUCoolerSettings coolerSettings = GetCoolerSettings();
      if (coolerSettings.Count > 0) {
        control.Value = coolerSettings.Cooler[0].CurrentLevel;
        ActivateSensor(control);
      }

      NvMemoryInfo memoryInfo = new NvMemoryInfo();
      memoryInfo.Version = NVAPI.GPU_MEMORY_INFO_VER;
      memoryInfo.Values = new uint[NVAPI.MAX_MEMORY_VALUES_PER_GPU];
      if (NVAPI.NvAPI_GPU_GetMemoryInfo != null && displayHandle.HasValue &&
        NVAPI.NvAPI_GPU_GetMemoryInfo(displayHandle.Value, ref memoryInfo) ==
        NvStatus.OK) {
        uint totalMemory = memoryInfo.Values[0];
        uint freeMemory = memoryInfo.Values[4];
        float usedMemory = Math.Max(totalMemory - freeMemory, 0);
        memoryLoad.Value = 100f * usedMemory / totalMemory;
        ActivateSensor(memoryLoad);
      }
    }

    private void SoftwareControlValueChanged(IControl control) {
      SaveDefaultFanSpeed();
      NvGPUCoolerLevels coolerLevels = new NvGPUCoolerLevels();
      coolerLevels.Version = NVAPI.GPU_COOLER_LEVELS_VER;
      coolerLevels.Levels = new NvLevel[NVAPI.MAX_COOLER_PER_GPU];
      coolerLevels.Levels[0].Level = (int)control.SoftwareValue;
      coolerLevels.Levels[0].Policy = 1;
      NVAPI.NvAPI_GPU_SetCoolerLevels(handle, 0, ref coolerLevels);
    }

    private void SaveDefaultFanSpeed() {
      if (!restoreDefaultFanSpeedRequired) {
        NvGPUCoolerSettings coolerSettings = GetCoolerSettings();
        if (coolerSettings.Count > 0) {
          restoreDefaultFanSpeedRequired = true;
          initialFanSpeedValue.Level = coolerSettings.Cooler[0].CurrentLevel;
          initialFanSpeedValue.Policy = coolerSettings.Cooler[0].CurrentPolicy;
        }
      }
    }

    private void ControlModeChanged(IControl control) {
      if (control.ControlMode == ControlMode.Default) 
      {
        RestoreDefaultFanSpeed();
      }
      else if (control.ControlMode == ControlMode.Auto) 
      {
          RestoreAutoFanSpeed();
      }
      else if (control.ControlMode == ControlMode.DirtyDefault)
      {
          RestoreDirtyFanSpeed(control.DefaultPolicy, control.DefaultLevel);
      }
      else 
      {
        SoftwareControlValueChanged(control);
      }
    }

    private void RestoreDefaultFanSpeed() {
      if (restoreDefaultFanSpeedRequired) {
        NvGPUCoolerLevels coolerLevels = new NvGPUCoolerLevels();
        coolerLevels.Version = NVAPI.GPU_COOLER_LEVELS_VER;
        coolerLevels.Levels = new NvLevel[NVAPI.MAX_COOLER_PER_GPU];
        coolerLevels.Levels[0] = initialFanSpeedValue;
        NVAPI.NvAPI_GPU_SetCoolerLevels(handle, 0, ref coolerLevels);
        restoreDefaultFanSpeedRequired = false;
      }
    }

    private void RestoreAutoFanSpeed()
    {
            NvGPUCoolerLevels coolerLevels = new NvGPUCoolerLevels();
            coolerLevels.Version = NVAPI.GPU_COOLER_LEVELS_VER;
            coolerLevels.Levels = new NvLevel[NVAPI.MAX_COOLER_PER_GPU];
            coolerLevels.Levels[0] = initialFanSpeedValue;
            coolerLevels.Levels[0].Policy = 8;
            NVAPI.NvAPI_GPU_SetCoolerLevels(handle, 0, ref coolerLevels);
            restoreDefaultFanSpeedRequired = false;
    }

    private void RestoreDirtyFanSpeed(int policy, int level)
    {
        NvGPUCoolerLevels coolerLevels = new NvGPUCoolerLevels();
        coolerLevels.Version = NVAPI.GPU_COOLER_LEVELS_VER;
        coolerLevels.Levels = new NvLevel[NVAPI.MAX_COOLER_PER_GPU];
        coolerLevels.Levels[0].Policy = policy;
        coolerLevels.Levels[0].Level = level;
        NVAPI.NvAPI_GPU_SetCoolerLevels(handle, 0, ref coolerLevels);
        restoreDefaultFanSpeedRequired = false;
    }
  }
}
