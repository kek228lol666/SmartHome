using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Models;

public class SmartKettle : SmartDevice, IEnergyConsumer
{
    public int WaterTemperature { get; private set; }

    public SmartKettle(string name, int waterTemperature) : base(name)
    {
        WaterTemperature = waterTemperature;
    }

    public override void TurnOn()
    {
        base.TurnOn();
        Console.WriteLine($"  Нагрев воды до {WaterTemperature}°C");
    }

    public double GetPowerConsumption() => IsOn ? 2000.0 : 0;

    public override string GetStatus()
    {
        string state = IsOn ? "вкл" : "выкл";
        return $"{Name} — {state}, целевая температура {WaterTemperature}°C";
    }
}

