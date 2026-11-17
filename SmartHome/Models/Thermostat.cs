using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Models;

public class Thermostat : SmartDevice, IEnergyConsumer
{
    public double TargetTemperature { get; private set; }

    public Thermostat(string name, double temperature) : base(name)
    {
        TargetTemperature = temperature;
    }

    public override void TurnOn()
    {
        base.TurnOn();
        Console.WriteLine($"  Целевая температура: {TargetTemperature}°C");
    }

    public double GetPowerConsumption() => IsOn ? 1500.0 : 0;

    public override string GetStatus()
    {
        string state = IsOn ? "вкл" : "выкл";
        return $"{Name} — {state}, цель {TargetTemperature}°C";
    }
}

