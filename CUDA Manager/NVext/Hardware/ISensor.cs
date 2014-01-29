using System;
using System.Collections.Generic;
using CUDA_Manager.NVext.Collections;

namespace CUDA_Manager.NVext.Hardware {

  public enum SensorType {
    Voltage, // V
    Clock, // MHz
    Temperature, // °C
    Load, // %
    Fan, // RPM
    Flow, // L/h
    Control, // %
    Level, // %
    Factor, // 1
    Power, // W
    Data, // GB = 2^30 Bytes    
  }

  public struct SensorValue {
    private readonly float value;
    private readonly DateTime time;

    public SensorValue(float value, DateTime time) {
      this.value = value;
      this.time = time;
    }

    public float Value { get { return value; } }
    public DateTime Time { get { return time; } }
  }

  public interface ISensor : IElement {

    IHardware Hardware { get; }

    SensorType SensorType { get; }
    Identifier Identifier { get; }

    string Name { get; set; }
    int Index { get; }

    bool IsDefaultHidden { get; }

    IReadOnlyArray<IParameter> Parameters { get; }

    float? Value { get; }
    float? Min { get; }
    float? Max { get; }

    void ResetMin();
    void ResetMax();

    IEnumerable<SensorValue> Values { get; }

    IControl Control { get; }
  }

}
