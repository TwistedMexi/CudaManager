namespace CUDA_Manager.NVext.Hardware {

  internal interface IGroup {

    IHardware[] Hardware { get; }

    string GetReport();

    void Close();
  }

}
