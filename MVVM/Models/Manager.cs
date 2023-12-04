using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebSockets;
using System.Windows.Threading;

namespace WarehouseAutomation.MVVM.Models
{
    /// <summary>
    /// Менеджер
    /// </summary>
    public class Manager
    {
        public Statistics _statisticsAll;
        public Statistics _statisticsDay;
        public Settings _settings;
        public List<RetailOutlets> _retailOutlets;
        public Warehouse _warehouse;
        public DispatcherTimer _timer;
        public List<string> NameProduct;
        private Random _random;
        public Manager()
        {
            _settings = new Settings();
            _statisticsDay = new Statistics();
            _statisticsAll = new Statistics();
            _warehouse = Warehouse();
            _retailOutlets = RetailOutlets();
            _timer = new DispatcherTimer();
            _random = new Random();
            NameProduct = new List<string>() 
            {
                "Яйца", 
                "Молоко", 
                "Хлеб", 
                "Масло", 
                "Рис", 
                "Гречка",
                "Макароны",
                "Печенье",
                "Майонез", 
                "Курица",
                "Сыр", 
                "Кефир",
                "Чипсы",
                "Мед", 
                "Сахар", 
                "Соль", 
                "Йогурт", 
                "Соки", 
                "Чай", 
                "Кофе"
            };
            TimerStart(_timer);
        }
        public void TimerStart(DispatcherTimer _timer)
        {
            _timer.Tick += new EventHandler(dispatcherTimer_Tick);
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Start();
        }
        /// <summary>
        /// моделирование
        /// </summary>
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Statistics._numberDays++;
            int countApplication = _random.Next(0, _retailOutlets.Count);
            List<RetailOutlets> temp_retailOutlets = new List<RetailOutlets>(_retailOutlets);
            int numberRetailOutlets;
            for (int i = 0; i < countApplication; i++)
            {
                numberRetailOutlets = _random.Next(0, temp_retailOutlets.Count - 1);
                //вывод сообщения, что магазин сделал заказ
                _warehouse.ApplicationProcessing(temp_retailOutlets[numberRetailOutlets].PreparationApplication());
                //вывод сообщения, что склад выполнил заказ
                temp_retailOutlets.RemoveAt(numberRetailOutlets);
            }
            _warehouse.WriteOffProducts();
            _warehouse.OrderingProductsWarehouse();
            _statisticsAll.AddStatistics(_statisticsDay);
        }

        /// <summary>
        /// Занесение типов продуктов на склад и его пополнение 
        /// </summary>
        public Warehouse Warehouse()
        {
            Warehouse warehouse = new Warehouse(_settings, _statisticsDay);
            warehouse.Products = new Dictionary<string, List<Product>>();
            List<string> TempProduct = new List<string>(NameProduct);
            int idx;
            for (int i = 0; i < _settings._numberTypesProducts; i++)
            {
                idx = _random.Next(0, TempProduct.Count);
                warehouse.Products.Add(TempProduct[idx], new List<Product>());
                TempProduct.RemoveAt(idx);
            }
            warehouse.OrderingProductsWarehouse();
            return warehouse;
        }
        /// <summary>
        /// Создание магазинов
        /// </summary>
        public List<RetailOutlets> RetailOutlets()
        {
            List<RetailOutlets> retailOutlets = new List<RetailOutlets>();
            for (int i = 1; i <= _settings._numberStores; i++)
            {
                retailOutlets.Add(new RetailOutlets($"Магазин #{i}", NameProduct, _settings));
            }
            return retailOutlets;
        }
    }
}
