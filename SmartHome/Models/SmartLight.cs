using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace SmartHome.Models;

public class SmartLight : SmartDevice, IEnergyConsumer
{
    public int Brightness { get; private set; }

    public SmartLight(string name, int brightness) : base(name)
    {
        Brightness = brightness;
    }

    public override void TurnOn()
    {
        base.TurnOn();
        Console.WriteLine($"  Яркость: {Brightness}%");
    }

    public void SetBrightness(int level)
    {
        Brightness = level;
        Console.WriteLine($"{Name}: яркость = {level}%");
    }

    public void SetBrightness(string preset)
    {
        if (preset == "night")
            Brightness = 15;
        else if (preset == "evening")
            Brightness = 40;
        else if (preset == "day")
            Brightness = 100;
        else
        {
            Console.WriteLine($"{Name}: неизвестный пресет \"{preset}\"");
            return;
        }

        Console.WriteLine($"{Name}: пресет \"{preset}\" -> {Brightness}%");
    }

    public double GetPowerConsumption() => IsOn ? 12.0 * (Brightness / 100.0) : 0;

    public override string GetStatus()
    {
        string state = IsOn ? "вкл" : "выкл";
        return $"{Name} — {state}, яркость {Brightness}%";
    }
}


