using ControlzEx.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAutomation.Properties;

namespace WarehouseAutomation.MVVM.Models
{
    public class Warehouse
    {
        private Settings _settings;
        private Statistics _statistics;
        private Random Random;
        public Warehouse(Settings settings, Statistics statisticsDay)
        {
            _settings = settings;
            _statistics = statisticsDay;
            CapacityWarehouse = _settings.StorageCapacityProduct;
            Random = new Random();
        }
        /// <summary>
        /// Вместимость склада по видим продукта 
        /// </summary>
        public int CapacityWarehouse { get; set; }
        /// <summary>
        /// Key - тип продукта, Value - список продуктов
        /// </summary>
        public Dictionary<string, List<Product>> Products { get; set; }
        /// <summary>
        /// Обработка заявки
        /// </summary>
        /// <param name="application">Заявка</param>
        public Dictionary<string, List<Product>> ApplicationProcessing(Applications application)
        {
            _statistics.TotalApplications++;
            Dictionary<string, List<Product>> products = new Dictionary<string, List<Product>>();
            if (Random.Next(0, 10) <= 8)
            {
                _statistics.CompletedApplications++;
                foreach (var product in application.Products)
                {
                    if (Products.ContainsKey(product.Key))
                    {
                        if (Products[product.Key].Count < product.Value)
                        {
                            products[product.Key] = new List<Product>(Products[product.Key]);
                            Products[product.Key].Clear();
                        }
                        else
                        {
                            products[product.Key] = new List<Product>(Products[product.Key].GetRange(Products[product.Key].Count - product.Value, product.Value));
                            Products[product.Key].RemoveRange(Products[product.Key].Count - product.Value, product.Value);
                        }                        
                        foreach (var item in products[product.Key])
                        {
                            _statistics.WarehouseProfit += (int)item.PriceSell - (int)item.PriceBuy;
                        }
                    }
                }
            }
            else
            {
                _statistics.RejectedApplications++;
            }
            return products;
        }
        /// <summary>
        ///  Заказ продуктов на склад
        /// </summary>
        public void OrderingProductsWarehouse()
        {
            uint Price;
            foreach (var product in Products)
            {
                if (product.Value.Count < 30)
                {
                    Price = Convert.ToUInt32(Random.Next(_settings.LowerNumberRangeRandom, _settings.UpperNumberRangeRandom)
                            * Random.Next(_settings.LowerNumberRangeRandom, _settings.UpperNumberRangeRandom)
                            * Random.Next(_settings.LowerNumberRangeRandom, _settings.UpperNumberRangeRandom));
                    for (int i = product.Value.Count; i < CapacityWarehouse; i++)
                    {                        
                        product.Value.Add(
                        new Product
                        (
                            (byte)Random.Next(_settings.LowerNumberRangeRandom, _settings.UpperNumberRangeRandom),
                            Price,
                            Convert.ToUInt32(Price * 1.1),
                            DateTime.Now.AddDays(Random.Next(_settings.LowerNumberRangeRandom + 10, _settings.UpperNumberRangeRandom + 10)))
                        );
                    }                    
                }
            }
        }
        /// <summary>
        /// Проверка продуктов 
        /// </summary>
        public void WriteOffProducts()
        {
            double days;
            foreach (var product in Products)
            {
                for(int i = 0; i < product.Value.Count;i ++)
                {
                    //days = product.Value[i].ExpirationDate.CompareTo(DateTime.Now.AddDays(_statistics.NumberDays));
                    days = (product.Value[i].ExpirationDate - DateTime.Now.AddDays(_statistics.NumberDays)).TotalDays;
                    if (days <= 0)
                    {
                        _statistics.WarehouseProfit -= (int)product.Value[i].PriceBuy;
                        product.Value.RemoveAt(i);
                    }
                    else if (days <= 5)
                    {
                        product.Value[i].PriceSell -= Convert.ToUInt32(product.Value[i].PriceSell * 0.25);
                    }
                }
            }
        }
    }
}
