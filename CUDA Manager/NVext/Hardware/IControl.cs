namespace CUDA_Manager.NVext.Hardware {

  public enum ControlMode {
    Default,
    Software,
    Auto,
    DirtyDefault
  }

  public interface IControl {

    Identifier Identifier { get; }

    ControlMode ControlMode { get; }

    float SoftwareValue { get; }

    void SetDefault();

    void SetAuto();

    void SetDirtyDefault(int policy, int level);

    float MinSoftwareValue { get; }
    float MaxSoftwareValue { get; }
    int DefaultPolicy { get; }
    int DefaultLevel { get; }

    void SetSoftware(float value);

  }
}
