namespace CUDA_Manager.NVext.Hardware {

  public interface IVisitor {
    void VisitHardware(IHardware hardware);
    void VisitSensor(ISensor sensor);
    void VisitParameter(IParameter parameter);
  }

}
