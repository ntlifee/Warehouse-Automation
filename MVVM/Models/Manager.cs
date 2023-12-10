using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.WebSockets;
using System.Windows.Input;
using System.Windows.Threading;

namespace WarehouseAutomation.MVVM.Models
{
    /// <summary>
    /// Менеджер
    /// </summary>
    public class Manager : BindableBase
    {
        public Statistics Statistics { get; set; }
        public bool IsTestingStart { get; private set; }
        public Settings Settings { get; set; }
        public ObservableCollection<string> Logs { get; set; }
        public ICommand StartCommand { get; }
        public ICommand StopCommand { get; }
        
        private List<RetailOutlets> _retailOutlets;
        private Warehouse _warehouse;
        private DispatcherTimer _timer;
        private List<string> _nameProduct;
        private Random _random;
        public Manager()
        {
            StartCommand = new DelegateCommand(() => TimerStart());
            StopCommand = new DelegateCommand(() => TimerStop());
            _nameProduct = new List<string>()
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
            Settings = new Settings();
            Logs = new ObservableCollection<string>();
            _random = new Random();            
            _timer = new DispatcherTimer();       
        }
        public void TimerStart()
        {
            IsTestingStart = true;
            Statistics = new Statistics();
            _retailOutlets = RetailOutlets();
            _warehouse = Warehouse();
            Logs.Clear();
            _timer.Tick += new EventHandler(dispatcherTimer_Tick);
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Start();
        }
        public void TimerStop()
        {
            IsTestingStart = false;
            _timer.Tick -= new EventHandler(dispatcherTimer_Tick);
            _timer.Stop();
        }
        /// <summary>
        /// моделирование
        /// </summary>
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Statistics.NumberDays++;
            Logs.Add($"Начался день {Statistics.NumberDays}.");
            _warehouse.WriteOffProducts();
            Logs.Add($"     Склад выполнил уценку продуктов.");
            _warehouse.OrderingProductsWarehouse();
            Logs.Add($"     Склад выполнил заказ недостающих продуктов.");
            int countApplication = _random.Next(_retailOutlets.Count / 2, _retailOutlets.Count);
            List<RetailOutlets> temp_retailOutlets = new List<RetailOutlets>(_retailOutlets);
            int numberRetailOutlets;
            for (int i = 0; i < countApplication; i++)
            {
                numberRetailOutlets = _random.Next(0, temp_retailOutlets.Count - 1);                
                //вывод сообщения, что магазин сделал заказ
                Logs.Add($"     {temp_retailOutlets[numberRetailOutlets].Name} сделал заказ.");
                _warehouse.ApplicationProcessing(temp_retailOutlets[numberRetailOutlets].PreparationApplication());
                //вывод сообщения, что склад выполнил заказ
                Logs.Add($"     Склад выполнил заказ для {temp_retailOutlets[numberRetailOutlets].Name}.");
                temp_retailOutlets.RemoveAt(numberRetailOutlets);
            }           
            if (Statistics.NumberDays == Settings.NumberSimulationDays)
            {
                TimerStop();
            }
        }

        /// <summary>
        /// Занесение типов продуктов на склад и его пополнение 
        /// </summary>
        public Warehouse Warehouse()
        {
            Warehouse warehouse = new Warehouse(Settings, Statistics);
            warehouse.Products = new Dictionary<string, List<ProductParameter>>();
            List<string> TempProduct = new List<string>(_nameProduct);
            int idx;
            for (int i = 0; i < Settings.NumberTypesProducts; i++)
            {
                idx = _random.Next(0, TempProduct.Count);
                warehouse.Products.Add(TempProduct[idx], new List<ProductParameter>());
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
            for (int i = 1; i <= Settings.NumberStores; i++)
            {
                retailOutlets.Add(new RetailOutlets($"Магазин #{i}", _nameProduct, Settings));
            }
            return retailOutlets;
        }
    }
}
