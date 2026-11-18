using System;
using System.Collections.Generic;

namespace MobileDevices
{
    class Program
    {
        const int MenuExit = 0;
        const int MenuAddLaptop = 1;
        const int MenuAddEbook = 2;
        const int MenuShowAll = 3;
        const int MenuDelete = 4;

        static void Main(string[] args)
        {

            List<MobileDevice> devices = new List<MobileDevice>();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Меню:");
                Console.WriteLine(" 1 - добавить ноутбук");
                Console.WriteLine(" 2 - добавить электронную книгу");
                Console.WriteLine(" 3 - вывести список устройств");
                Console.WriteLine(" 4 - удалить устройство");
                Console.WriteLine(" 0 - выход");

                int choice = ReadInt("Выбор: ");

                if (choice == MenuExit)
                {
                    break;
                }
                else if (choice == MenuAddLaptop)
                {
                    devices.Add(InputLaptop());
                    Console.WriteLine("Ноутбук добавлен.");
                }
                else if (choice == MenuAddEbook)
                {
                    devices.Add(InputEbook());
                    Console.WriteLine("Электронная книга добавлена.");
                }
                else if (choice == MenuShowAll)
                {
                    PrintDevices(devices);
                }
                else if (choice == MenuDelete)
                {
                    DeleteDevice(devices);
                }
                else
                {
                    Console.WriteLine("Нет такого пункта меню.");
                }
            }

            Console.WriteLine("Завершение программы.");
        }

        static Laptop InputLaptop()
        {
            string brand = ReadString("Фирма: ");
            double price = ReadDouble("Цена: ");
            string processor = ReadString("Процессор: ");
            bool hasGpu = ReadYesNo("Игровая видеокарта (1 - есть, 0 - нет): ");
            int ram = ReadInt("ОЗУ, ГБ: ");

            return new Laptop(brand, price, processor, hasGpu, ram);
        }

        static Ebook InputEbook()
        {
            string brand = ReadString("Фирма: ");
            double price = ReadDouble("Цена: ");
            double screenSize = ReadDouble("Размер экрана, дюймы: ");
            bool hasBacklight = ReadYesNo("Подсветка (1 - есть, 0 - нет): ");
            int memory = ReadInt("Память, ГБ: ");

            return new Ebook(brand, price, screenSize, hasBacklight, memory);
        }

        static void PrintDevices(List<MobileDevice> devices)
        {
            Console.WriteLine("--- Список устройств ---");
            if (devices.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            for (int i = 0; i < devices.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + devices[i].GetInfo());
            }
        }

        static void DeleteDevice(List<MobileDevice> devices)
        {
            if (devices.Count == 0)
            {
                Console.WriteLine("Список пуст, удалять нечего.");
                return;
            }

            PrintDevices(devices);
            int number = ReadInt("Номер устройства для удаления: ");

            if (number < 1 || number > devices.Count)
            {
                Console.WriteLine("Неверный номер.");
                return;
            }

            devices.RemoveAt(number - 1);
            Console.WriteLine("Устройство удалено.");
        }

        static string ReadString(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? text = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(text))
                {
                    return text.Trim();
                }
                Console.WriteLine("Строка не должна быть пустой.");
            }
        }

        static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                int number;
                if (int.TryParse(Console.ReadLine(), out number))
                {
                    return number;
                }
                Console.WriteLine("Нужно ввести целое число.");
            }
        }

        static double ReadDouble(string message)
        {
            while (true)
            {
                Console.Write(message);
                double number;
                if (double.TryParse(Console.ReadLine(), out number))
                {
                    return number;
                }
                Console.WriteLine("Нужно ввести число.");
            }
        }

        static bool ReadYesNo(string message)
        {
            while (true)
            {
                int answer = ReadInt(message);
                if (answer == 1)
                {
                    return true;
                }
                if (answer == 0)
                {
                    return false;
                }
                Console.WriteLine("Введите 1 или 0.");
            }
        }
    }
}
