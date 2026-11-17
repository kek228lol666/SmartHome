using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Models;

public class SecurityCamera : SmartDevice, IEnergyConsumer
{
    public bool IsRecording { get; private set; }

    public SecurityCamera(string name) : base(name)
    {
        IsRecording = false;
    }

    public override void TurnOn()
    {
        base.TurnOn();
        IsRecording = true;
        Console.WriteLine("  Запись видео начата");
    }

    public override void TurnOff()
    {
        base.TurnOff();
        IsRecording = false;
        Console.WriteLine("  Запись видео остановлена");
    }

    public double GetPowerConsumption() => IsOn ? 8.5 : 0;

    public override string GetStatus()
    {
        string state = IsOn ? "вкл" : "выкл";
        string rec = IsRecording ? "идёт" : "нет";
        return $"{Name} — {state}, запись: {rec}";
    }
}

