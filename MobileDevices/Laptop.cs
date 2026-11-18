namespace MobileDevices
{
    // Производный класс Ноутбук
    public class Laptop : MobileDevice
    {
        public const string DefaultProcessor = "не задан";
        public const int DefaultRam = 1;

        private string _processor;
        private int _ram;

        // Модель процессора
        public string Processor
        {
            get { return _processor; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _processor = value;
                }
            }
        }

        // Есть ли игровая видеокарта
        public bool HasGpu { get; set; }

        // ОЗУ
        public int Ram
        {
            get { return _ram; }
            set
            {
                if (value > 0)
                {
                    _ram = value;
                }
            }
        }

        // Конструктор по умолчанию
        public Laptop() : base()
        {
            _processor = DefaultProcessor;
            HasGpu = false;
            _ram = DefaultRam;
        }

        // Конструктор с параметрами
        public Laptop(string brand, double price, string processor, bool hasGpu, int ram)
            : base(brand, price)
        {
            _processor = DefaultProcessor;
            _ram = DefaultRam;

            Processor = processor;
            HasGpu = hasGpu;
            Ram = ram;
        }

        // Переопределённый виртуальный метод
        public override string GetInfo()
        {
            string gpuText;
            if (HasGpu)
            {
                gpuText = "есть";
            }
            else
            {
                gpuText = "нет";
            }

            return "Ноутбук: " + GetCommonInfo() + ", процессор " + Processor + ", игровая видеокарта: " + gpuText + ", ОЗУ " + Ram + " ГБ";
        }
    }
}
