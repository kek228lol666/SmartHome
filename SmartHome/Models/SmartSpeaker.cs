using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Models;

public class SmartSpeaker : SmartDevice, IEnergyConsumer
{
    public int Volume { get; private set; }

    public SmartSpeaker(string name, int volume) : base(name)
    {
        Volume = volume;
    }

    public double GetPowerConsumption() => IsOn ? 25.0 : 0;

    public override string GetStatus()
    {
        string state = IsOn ? "вкл" : "выкл";
        return $"{Name} — {state}, громкость {Volume}";
    }
}

