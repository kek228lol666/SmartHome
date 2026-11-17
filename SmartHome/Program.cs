using SmartHome.Models;

var lamp = new SmartLight("Люстра в зале", 80);

// Демонстрация перегрузки методов (статический полиморфизм)
Console.WriteLine("=== Демонстрация перегрузки SetBrightness ===");
lamp.SetBrightness(65);
lamp.SetBrightness("night");
Console.WriteLine();

SmartDevice[] devices =
{
    lamp,
    new Thermostat("Термостат", 22.5),
    new SmartSpeaker("Колонка Алиса", 60),
    new SecurityCamera("Камера у входа"),
    new RobotVacuum("Пылесос Xiaomi", 85),
    new SmartKettle("Чайник на кухне", 95)
};

while (true)
{
    Console.WriteLine("\n=== УМНЫЙ ДОМ ===");
    Console.WriteLine("1. Показать все устройства");
    Console.WriteLine("2. Включить все");
    Console.WriteLine("3. Выключить все");
    Console.WriteLine("4. Включить устройство по имени");
    Console.WriteLine("5. Выключить устройство по имени");
    Console.WriteLine("6. Статистика (включено / выключено)");
    Console.WriteLine("7. Суммарное энергопотребление");
    Console.WriteLine("0. Выход");
    Console.Write("Выберите пункт: ");

    string? choice = Console.ReadLine();
    Console.WriteLine();

    switch (choice)
    {
        case "1":
            foreach (var device in devices)
            {
                Console.WriteLine(device.GetStatus());
            }
            break;

        case "2":
            foreach (var device in devices)
            {
                device.TurnOn();
            }
            break;

        case "3":
            foreach (var device in devices)
            {
                device.TurnOff();
            }
            break;

        case "4":
            ToggleDeviceByName(devices, true);
            break;

        case "5":
            ToggleDeviceByName(devices, false);
            break;

        case "6":
            int onCount = 0;
            int offCount = 0;
            foreach (var device in devices)
            {
                if (device.IsOn) onCount++;
                else offCount++;
            }
            Console.WriteLine($"Включено: {onCount} | Выключено: {offCount}");
            break;

        case "7":
            double totalWatts = 0;
            foreach (var device in devices)
            {
                if (device is IEnergyConsumer consumer)
                {
                    totalWatts += consumer.GetPowerConsumption();
                }
            }
            Console.WriteLine($"Текущее энергопотребление: {totalWatts} Вт");
            break;

        case "0":
            Console.WriteLine("Выход из программы...");
            return;

        default:
            Console.WriteLine("Неверный пункт меню. Попробуйте снова.");
            break;
    }
}

static void ToggleDeviceByName(SmartDevice[] devices, bool turnOn)
{
    Console.Write("Введите название устройства: ");
    string? name = Console.ReadLine();

    foreach (var device in devices)
    {
        if (string.Equals(device.Name, name, StringComparison.OrdinalIgnoreCase))
        {
            if (turnOn) device.TurnOn();
            else device.TurnOff();
            return;
        }
    }

    Console.WriteLine("Устройство с таким именем не найдено.");
}

