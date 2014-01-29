using System;
using System.Globalization;

namespace CUDA_Manager.NVext.Hardware {

  internal delegate void ControlEventHandler(Control control);

  internal class Control : IControl {

    private readonly Identifier identifier;
    private ControlMode mode;
    private float softwareValue;
    private float minSoftwareValue;
    private float maxSoftwareValue;
    private int defaultPolicy;
    private int defaultLevel;

    public Control(ISensor sensor, float minSoftwareValue,
      float maxSoftwareValue, int defaultPolicy, int defaultLevel) 
    {
      this.identifier = new Identifier(sensor.Identifier, "control");
      this.minSoftwareValue = minSoftwareValue;
      this.maxSoftwareValue = maxSoftwareValue;
      this.defaultPolicy = defaultPolicy;
      this.defaultLevel = defaultLevel;

      this.softwareValue = 0;
      int mode = 0;
      this.mode = (ControlMode)mode;
    }

    public Identifier Identifier {
      get {
        return identifier;
      }
    }

    public ControlMode ControlMode {
      get {
        return mode;
      }
      private set {
        if (mode != value) {
          mode = value;
          if (ControlModeChanged != null)
            ControlModeChanged(this);
        }
      }
    }

    public float SoftwareValue {
      get {
        return softwareValue;
      }
      private set {
        if (softwareValue != value) {
          softwareValue = value;
          if (SoftwareControlValueChanged != null)
            SoftwareControlValueChanged(this);
        }
      }
    }

    public void SetDirtyDefault(int policy, int level) {
        this.defaultPolicy = policy;
        this.defaultLevel = level;
      ControlMode = ControlMode.DirtyDefault;
    }

    public void SetDefault()
    {
        ControlMode = ControlMode.Default;
    }

    public void SetAuto()
    {
        ControlMode = ControlMode.Auto;
    }

    public float MinSoftwareValue 
    {
        get
        {
            return minSoftwareValue;
        }
    }

    public float MaxSoftwareValue 
    {
        get
        {
            return maxSoftwareValue;
        }
    }

    public int DefaultPolicy
    {
        get
        {
            return defaultPolicy;
        }
    }

    public int DefaultLevel
    {
        get
        {
            return defaultLevel;
        }
    }

    public void SetSoftware(float value) {
      ControlMode = ControlMode.Software;
      SoftwareValue = value;
    }

    internal event ControlEventHandler ControlModeChanged;
    internal event ControlEventHandler SoftwareControlValueChanged;
  }
}
