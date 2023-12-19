using DevExpress.Mvvm.Native;
using System;
using System.Collections.Generic;
using WarehouseAutomation.MVVM.Models.Interfaces;

namespace WarehouseAutomation.MVVM.Models
{
    public class Warehouse : IWarehouse
    {
        private Settings _settings;
        private Statistics _statistics;
        private Random _random;
        public Warehouse(Settings settings, Statistics statisticsDay)
        {            
            _settings = settings;
            _statistics = statisticsDay;            
            _random = new Random();
            CapacityWarehouse = _settings.StorageCapacityProduct;
        }
        /// <summary>
        /// Вместимость склада по видим продукта 
        /// </summary>
        public int CapacityWarehouse { get; set; }
        /// <summary>
        /// Key - тип продукта, Value - список продуктов
        /// </summary>
        public List<Product> Products { get; set; }
        /// <summary>
        /// Обработка заявки
        /// </summary>
        /// <param name="application">Заявка</param>
        public List<Product> ApplicationProcessing(Applications application)
        {
            _statistics.TotalApplications++;
            List<Product> products = new List<Product>();
            if (_random.Next(0, 10) <= 8)
            {
                _statistics.CompletedApplications++;                
                foreach (var product in application.Products)
                {
                    int idx = Products.FindIndex(x => x.Name == product.Key);
                    if (idx != -1)
                    {
                        if (Products[idx].Parameters.Count < product.Value)
                        {
                            products.Add(new Product(product.Key, new List<ProductParameter>(Products[idx].Parameters)));
                            Products[idx].Parameters.Clear();
                        }
                        else
                        {
                            products.Add(new Product(product.Key, new List<ProductParameter>(Products[idx].Parameters.GetRange(Products[idx].Parameters.Count - product.Value, product.Value))));
                            Products[idx].Parameters.RemoveRange(Products[idx].Parameters.Count - product.Value, product.Value);
                        }                        
                        foreach (var item in products[products.Count - 1].Parameters)
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
                if (product.Parameters.Count < 30)
                {
                    Price = Convert.ToUInt32(_random.Next(_settings.LowerNumberRangeRandom, _settings.UpperNumberRangeRandom)
                            * _random.Next(_settings.LowerNumberRangeRandom, _settings.UpperNumberRangeRandom)
                            * _random.Next(_settings.LowerNumberRangeRandom, _settings.UpperNumberRangeRandom));
                    for (int i = product.Parameters.Count; i < CapacityWarehouse; i++)
                    {                        
                        product.Parameters.Add(
                        new ProductParameter
                        (
                            (byte)_random.Next(_settings.LowerNumberRangeRandom, _settings.UpperNumberRangeRandom),
                            Price,
                            Convert.ToUInt32(Price * 1.1),
                            DateTime.Now.AddDays(_random.Next(_settings.LowerNumberRangeRandom + 10, _settings.UpperNumberRangeRandom + 10)))
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
                for(int i = 0; i < product.Parameters.Count;i ++)
                {
                    //days = product.Value[i].ExpirationDate.CompareTo(DateTime.Now.AddDays(_statistics.NumberDays));
                    days = (product.Parameters[i].ExpirationDate - DateTime.Now.AddDays(_statistics.NumberDays)).TotalDays;
                    if (days <= 0)
                    {
                        _statistics.WarehouseProfit -= (int)product.Parameters[i].PriceBuy;
                        product.Parameters.RemoveAt(i);
                    }
                    else if (days <= 5)
                    {
                        product.Parameters[i].PriceSell -= Convert.ToUInt32(product.Parameters[i].PriceSell * 0.25);
                    }
                }
            }
        }
    }
}
