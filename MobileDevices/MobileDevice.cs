namespace MobileDevices
{
    // Базовый класс Мобильное устройство
    public class MobileDevice
    {
        public const string DefaultBrand = "не задано";
        public const double DefaultPrice = 1.0;

        private string _brand;
        private double _price;

        // Производитель
        public string Brand
        {
            get { return _brand; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _brand = value;
                }
            }
        }

        // Цена
        public double Price
        {
            get { return _price; }
            set
            {
                if (value > 0)
                {
                    _price = value;
                }
            }
        }

        // Конструктор по умолчанию
        public MobileDevice()
        {
            _brand = DefaultBrand;
            _price = DefaultPrice;
        }

        // Конструктор с параметрами
        public MobileDevice(string brand, double price) : this()
        {
            Brand = brand;
            Price = price;
        }

        // Общая часть описания для всех устройств.
        protected string GetCommonInfo()
        {
            return "фирма " + Brand + ", цена " + Price + " руб.";
        }

        // Описание устройства
        public virtual string GetInfo()
        {
            return "Мобильное устройство: " + GetCommonInfo();
        }

        // Переопределение ToString
        public override string ToString()
        {
            return GetInfo();
        }
    }
}
