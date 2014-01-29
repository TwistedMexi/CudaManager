using System;
using System.Globalization;

namespace CUDA_Manager.NVext.Hardware {

  internal struct ParameterDescription {
    private readonly string name;
    private readonly string description;
    private readonly float defaultValue;    

    public ParameterDescription(string name, string description, 
      float defaultValue) {
      this.name = name;
      this.description = description;
      this.defaultValue = defaultValue;
    }

    public string Name { get { return name; } }

    public string Description { get { return description; } }

    public float DefaultValue { get { return defaultValue; } }
  }

  internal class Parameter : IParameter {
    private readonly ISensor sensor;
    private ParameterDescription description;
    private float value;
    private bool isDefault;

    public Parameter(ParameterDescription description, ISensor sensor) 
    {
      this.sensor = sensor;
      this.description = description;
      this.isDefault = true;
      this.value = description.DefaultValue;
    }

    public ISensor Sensor {
      get {
        return sensor;
      }
    }

    public Identifier Identifier {
      get {
        return new Identifier(sensor.Identifier, "parameter",
          Name.Replace(" ", "").ToLowerInvariant());
      }
    }

    public string Name { get { return description.Name; } }

    public string Description { get { return description.Description; } }

    public float Value {
      get {
        return value;
      }
      set {
        this.isDefault = false;
        this.value = value;
      }
    }

    public float DefaultValue { 
      get { return description.DefaultValue; } 
    }

    public bool IsDefault {
      get { return isDefault; }
      set {
        this.isDefault = value;
        if (value) {
          this.value = description.DefaultValue;
        }
      }
    }

    public void Accept(IVisitor visitor) {
      if (visitor == null)
        throw new ArgumentNullException("visitor");
      visitor.VisitParameter(this);
    }

    public void Traverse(IVisitor visitor) { }
  }
}
