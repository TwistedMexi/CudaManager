using System;
using CUDA_Manager.NVext.Collections;

namespace CUDA_Manager.NVext.Hardware {
  internal abstract class Hardware : IHardware {

    private readonly Identifier identifier;
    protected readonly string name;
    private string customName;
    protected readonly ListSet<ISensor> active = new ListSet<ISensor>();

    public Hardware(string name, Identifier identifier) {
      this.identifier = identifier;
      this.name = name;
      this.customName = name;
    }

    public IHardware[] SubHardware {
      get { return new IHardware[0]; }
    }

    public virtual IHardware Parent {
      get { return null; }
    }

    public virtual ISensor[] Sensors {
      get { return active.ToArray(); }
    }

    protected virtual void ActivateSensor(ISensor sensor) {
      if (active.Add(sensor)) 
        if (SensorAdded != null)
          SensorAdded(sensor);
    }

    protected virtual void DeactivateSensor(ISensor sensor) {
      if (active.Remove(sensor))
        if (SensorRemoved != null)
          SensorRemoved(sensor);     
    }

    public string Name {
      get {
        return customName;
      }
      set {
        if (!string.IsNullOrEmpty(value))
          customName = value;
        else
          customName = name;
      }
    }

    public Identifier Identifier {
      get {
        return identifier;
      }
    }

    #pragma warning disable 67
    public event SensorEventHandler SensorAdded;
    public event SensorEventHandler SensorRemoved;
    #pragma warning restore 67
  
    
    public abstract HardwareType HardwareType { get; }

    public virtual string GetReport() {
      return null;
    }

    public abstract void Update();

    public void Accept(IVisitor visitor) {
      if (visitor == null)
        throw new ArgumentNullException("visitor");
      visitor.VisitHardware(this);
    }

    public virtual void Traverse(IVisitor visitor) {
      foreach (ISensor sensor in active)
        sensor.Accept(visitor);
    }
  }
}
