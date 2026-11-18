namespace MobileDevices
{
    // Производный класс Электронная книга
    public class Ebook : MobileDevice
    {
        public const double DefaultScreenSize = 1.0;
        public const int DefaultMemory = 1;

        private double _screenSize;
        private int _memory;

        // Диагональ экрана
        public double ScreenSize
        {
            get { return _screenSize; }
            set
            {
                if (value > 0)
                {
                    _screenSize = value;
                }
            }
        }

        // Есть ли подсветка экрана
        public bool HasBacklight { get; set; }

        // Память
        public int Memory
        {
            get { return _memory; }
            set
            {
                if (value > 0)
                {
                    _memory = value;
                }
            }
        }

        // Конструктор по умолчанию
        public Ebook() : base()
        {
            _screenSize = DefaultScreenSize;
            HasBacklight = false;
            _memory = DefaultMemory;
        }

        // Конструктор с параметрами
        public Ebook(string brand, double price, double screenSize, bool hasBacklight, int memory)
            : base(brand, price)
        {
            _screenSize = DefaultScreenSize;
            _memory = DefaultMemory;

            ScreenSize = screenSize;
            HasBacklight = hasBacklight;
            Memory = memory;
        }

        // Переопределённый виртуальный метод
        public override string GetInfo()
        {
            string backlightText;
            if (HasBacklight)
            {
                backlightText = "есть";
            }
            else
            {
                backlightText = "нет";
            }

            return "Электронная книга: " + GetCommonInfo() + ", экран " + ScreenSize + " дюймов" + ", подсветка: " + backlightText + ", память " + Memory + " ГБ";
        }
    }
}
