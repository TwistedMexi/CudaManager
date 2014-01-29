using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CUDA_Manager.NVext.Hardware.Nvidia {

  internal class NvidiaGroup {
   
    private readonly List<Hardware> hardware = new List<Hardware>();
    private readonly StringBuilder report = new StringBuilder();

    public NvidiaGroup() {
      if (!NVAPI.IsAvailable)
        return;

      report.AppendLine("NVAPI");
      report.AppendLine();

      string version;
      if (NVAPI.NvAPI_GetInterfaceVersionString(out version) == NvStatus.OK) {
        report.Append("Version: ");
        report.AppendLine(version);
      }

      NvPhysicalGpuHandle[] handles = 
        new NvPhysicalGpuHandle[NVAPI.MAX_PHYSICAL_GPUS];
      int count;
      if (NVAPI.NvAPI_EnumPhysicalGPUs == null) {
        report.AppendLine("Error: NvAPI_EnumPhysicalGPUs not available");
        report.AppendLine();
        return;
      } else {        
        NvStatus status = NVAPI.NvAPI_EnumPhysicalGPUs(handles, out count);
        if (status != NvStatus.OK) {
          report.AppendLine("Status: " + status);
          report.AppendLine();
          return;
        }
      }

      IDictionary<NvPhysicalGpuHandle, NvDisplayHandle> displayHandles =
        new Dictionary<NvPhysicalGpuHandle, NvDisplayHandle>();

      if (NVAPI.NvAPI_EnumNvidiaDisplayHandle != null &&
        NVAPI.NvAPI_GetPhysicalGPUsFromDisplay != null) 
      {
        NvStatus status = NvStatus.OK;
        int i = 0;
        while (status == NvStatus.OK) {
          NvDisplayHandle displayHandle = new NvDisplayHandle();
          status = NVAPI.NvAPI_EnumNvidiaDisplayHandle(i, ref displayHandle);
          i++;

          if (status == NvStatus.OK) {
            NvPhysicalGpuHandle[] handlesFromDisplay =
              new NvPhysicalGpuHandle[NVAPI.MAX_PHYSICAL_GPUS];
            uint countFromDisplay;
            if (NVAPI.NvAPI_GetPhysicalGPUsFromDisplay(displayHandle,
              handlesFromDisplay, out countFromDisplay) == NvStatus.OK) {
              for (int j = 0; j < countFromDisplay; j++) {
                if (!displayHandles.ContainsKey(handlesFromDisplay[j]))
                  displayHandles.Add(handlesFromDisplay[j], displayHandle);
              }
            }
          }
        }
      }

      report.Append("Number of GPUs: ");
      report.AppendLine(count.ToString(CultureInfo.InvariantCulture));

      for (int i = 0; i < count; i++) {
        NvDisplayHandle displayHandle;
        displayHandles.TryGetValue(handles[i], out displayHandle);
        hardware.Add(new NvidiaGPU(i, handles[i], displayHandle));
      }

      report.AppendLine();
    }

    public IHardware[] Hardware {
      get {
        return hardware.ToArray();
      }
    }

    public string GetReport() {
      return report.ToString();
    }
  }
}
