using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using CUDA_Manager.NVext.Collections;

namespace CUDA_Manager.NVext.Hardware {

  internal class Sensor : ISensor {

    private readonly string defaultName;
    private string name;
    private readonly int index;
    private readonly bool defaultHidden;
    private readonly SensorType sensorType;
    private readonly Hardware hardware;
    private readonly ReadOnlyArray<IParameter> parameters;
    private float? currentValue;
    private float? minValue;
    private float? maxValue;
    private readonly RingCollection<SensorValue> 
      values = new RingCollection<SensorValue>();
    private IControl control;
    
    private float sum;
    private int count;
   
    public Sensor(string name, int index, SensorType sensorType,
      Hardware hardware) : 
      this(name, index, sensorType, hardware, null) { }

    public Sensor(string name, int index, SensorType sensorType,
      Hardware hardware, ParameterDescription[] parameterDescriptions) :
      this(name, index, false, sensorType, hardware,
        parameterDescriptions) { }

    public Sensor(string name, int index, bool defaultHidden, 
      SensorType sensorType, Hardware hardware, 
      ParameterDescription[] parameterDescriptions) 
    {           
      this.index = index;
      this.defaultHidden = defaultHidden;
      this.sensorType = sensorType;
      this.hardware = hardware;
      Parameter[] parameters = new Parameter[parameterDescriptions == null ?
        0 : parameterDescriptions.Length];
      for (int i = 0; i < parameters.Length; i++ ) 
        parameters[i] = new Parameter(parameterDescriptions[i], this);
      this.parameters = parameters;

      this.defaultName = name; 
      this.name = name;  
    }

    private void AppendValue(float value, DateTime time) {
      if (values.Count >= 2 && values.Last.Value == value && 
        values[values.Count - 2].Value == value) {
        values.Last = new SensorValue(value, time);
        return;
      } 

      values.Append(new SensorValue(value, time));
    }

    public IHardware Hardware {
      get { return hardware; }
    }

    public SensorType SensorType {
      get { return sensorType; }
    }

    public Identifier Identifier {
      get {
        return new Identifier(hardware.Identifier,
          sensorType.ToString().ToLowerInvariant(),
          index.ToString(CultureInfo.InvariantCulture));
      }
    }

    public string Name {
      get { 
        return name; 
      }
      set {
        if (!string.IsNullOrEmpty(value)) 
          name = value;          
        else 
          name = defaultName;
      }
    }

    public int Index {
      get { return index; }
    }

    public bool IsDefaultHidden {
      get { return defaultHidden; }
    }

    public IReadOnlyArray<IParameter> Parameters {
      get { return parameters; }
    }

    public float? Value {
      get { 
        return currentValue; 
      }
      set {
        DateTime now = DateTime.UtcNow;
        while (values.Count > 0 && (now - values.First.Time).TotalDays > 1)
          values.Remove();

        if (value.HasValue) {
          sum += value.Value;
          count++;
          if (count == 4) {
            AppendValue(sum / count, now);
            sum = 0;
            count = 0;
          }
        }

        this.currentValue = value;
        if (minValue > value || !minValue.HasValue)
          minValue = value;
        if (maxValue < value || !maxValue.HasValue)
          maxValue = value;
      }
    }

    public float? Min { get { return minValue; } }
    public float? Max { get { return maxValue; } }

    public void ResetMin() {
      minValue = null;
    }

    public void ResetMax() {
      maxValue = null;
    }

    public IEnumerable<SensorValue> Values {
      get { return values; }
    }    

    public void Accept(IVisitor visitor) {
      if (visitor == null)
        throw new ArgumentNullException("visitor");
      visitor.VisitSensor(this);
    }

    public void Traverse(IVisitor visitor) {
      foreach (IParameter parameter in parameters)
        parameter.Accept(visitor);
    }

    public IControl Control {
      get {
        return control;
      }
      internal set {
        this.control = value;
      }
    }
  }
}
