using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MobileDevices;

namespace MobileDevices.Tests
{
    [TestClass]
    public class DeviceTests
    {
        [TestMethod]
        public void MobileDevice_DefaultConstructor_SetsDefaultValues()
        {
            MobileDevice device = new MobileDevice();

            Assert.AreEqual(MobileDevice.DefaultBrand, device.Brand);
            Assert.AreEqual(MobileDevice.DefaultPrice, device.Price);
        }

        [TestMethod]
        public void MobileDevice_ConstructorWithParams_SetsValues()
        {
            MobileDevice device = new MobileDevice("Generic", 5000);

            Assert.AreEqual("Generic", device.Brand);
            Assert.AreEqual(5000.0, device.Price);
        }

        [TestMethod]
        public void MobileDevice_ConstructorWithWrongParams_SetsDefaultValues()
        {
            MobileDevice device = new MobileDevice("", -100);

            Assert.AreEqual(MobileDevice.DefaultBrand, device.Brand);
            Assert.AreEqual(MobileDevice.DefaultPrice, device.Price);
        }

        [TestMethod]
        public void MobileDevice_SetZeroPrice_PriceNotChanged()
        {
            MobileDevice device = new MobileDevice("Generic", 5000);

            device.Price = 0;

            Assert.AreEqual(5000.0, device.Price);
        }

        [TestMethod]
        public void MobileDevice_GetInfo_ReturnsCorrectText()
        {
            MobileDevice device = new MobileDevice("Generic", 5000);

            string expected = "Мобильное устройство: фирма Generic, цена 5000 руб.";

            Assert.AreEqual(expected, device.GetInfo());
        }

        [TestMethod]
        public void Laptop_DefaultConstructor_SetsDefaultValues()
        {
            Laptop laptop = new Laptop();

            Assert.AreEqual(MobileDevice.DefaultBrand, laptop.Brand);
            Assert.AreEqual(Laptop.DefaultProcessor, laptop.Processor);
            Assert.IsFalse(laptop.HasGpu);
            Assert.AreEqual(Laptop.DefaultRam, laptop.Ram);
        }

        [TestMethod]
        public void Laptop_ConstructorWithParams_SetsAllValues()
        {
            Laptop laptop = new Laptop("Lenovo", 75000, "Intel i5", true, 16);

            Assert.AreEqual("Lenovo", laptop.Brand);
            Assert.AreEqual(75000.0, laptop.Price);
            Assert.AreEqual("Intel i5", laptop.Processor);
            Assert.IsTrue(laptop.HasGpu);
            Assert.AreEqual(16, laptop.Ram);
        }

        [TestMethod]
        public void Laptop_ChangeProperties_ValuesChanged()
        {
            Laptop laptop = new Laptop("Lenovo", 75000, "Intel i5", true, 16);

            laptop.Processor = "AMD Ryzen 7";
            laptop.Ram = 32;

            Assert.AreEqual("AMD Ryzen 7", laptop.Processor);
            Assert.AreEqual(32, laptop.Ram);
        }

        [TestMethod]
        public void Laptop_SetNegativeRam_RamNotChanged()
        {
            Laptop laptop = new Laptop("Lenovo", 75000, "Intel i5", true, 16);

            laptop.Ram = -8;

            Assert.AreEqual(16, laptop.Ram);
        }

        [TestMethod]
        public void Laptop_GetInfo_ReturnsCorrectText()
        {
            Laptop laptop = new Laptop("Lenovo", 75000, "Intel i5", true, 16);

            string expected = "Ноутбук: фирма Lenovo, цена 75000 руб., процессор Intel i5, " + "игровая видеокарта: есть, ОЗУ 16 ГБ";

            Assert.AreEqual(expected, laptop.GetInfo());
        }

        [TestMethod]
        public void Ebook_ConstructorWithParams_SetsAllValues()
        {
            Ebook ebook = new Ebook("PocketBook", 12000, 6, true, 8);

            Assert.AreEqual("PocketBook", ebook.Brand);
            Assert.AreEqual(12000.0, ebook.Price);
            Assert.AreEqual(6.0, ebook.ScreenSize);
            Assert.IsTrue(ebook.HasBacklight);
            Assert.AreEqual(8, ebook.Memory);
        }

        [TestMethod]
        public void Ebook_ConstructorWithWrongParams_SetsDefaultValues()
        {
            Ebook ebook = new Ebook("PocketBook", 12000, -6, false, 0);

            Assert.AreEqual(Ebook.DefaultScreenSize, ebook.ScreenSize);
            Assert.AreEqual(Ebook.DefaultMemory, ebook.Memory);
        }

        [TestMethod]
        public void Ebook_GetInfo_ReturnsCorrectText()
        {
            Ebook ebook = new Ebook("Kindle", 10000, 6, false, 16);

            string expected = "Электронная книга: фирма Kindle, цена 10000 руб., экран 6 дюймов, " + "подсветка: нет, память 16 ГБ";

            Assert.AreEqual(expected, ebook.GetInfo());
        }

        [TestMethod]
        public void Polymorphism_BaseReference_CallsDerivedMethod()
        {
            MobileDevice device = new Laptop("Asus", 90000, "Intel i7", false, 32);

            string info = device.GetInfo();

            Assert.IsTrue(info.StartsWith("Ноутбук:"));
            Assert.AreEqual(device.GetInfo(), device.ToString());
        }

        [TestMethod]
        public void Polymorphism_ListOfDevices_EachDeviceReturnsOwnInfo()
        {
            List<MobileDevice> devices = new List<MobileDevice>();
            devices.Add(new MobileDevice("Generic", 5000));
            devices.Add(new Laptop("Lenovo", 75000, "Intel i5", true, 16));
            devices.Add(new Ebook("PocketBook", 12000, 6, true, 8));

            Assert.AreEqual(3, devices.Count);
            Assert.IsTrue(devices[0].GetInfo().StartsWith("Мобильное устройство:"));
            Assert.IsTrue(devices[1].GetInfo().StartsWith("Ноутбук:"));
            Assert.IsTrue(devices[2].GetInfo().StartsWith("Электронная книга:"));
        }
    }
}
