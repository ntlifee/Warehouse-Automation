using System;
using System.Collections.Generic;
using System.Windows.Navigation;
using WarehouseAutomation.MVVM.Models.Interfaces;

namespace WarehouseAutomation.MVVM.Models
{
    /// <summary>
    /// Торговые точки 
    /// </summary>
    public class RetailOutlets : IRetailOutlets
    {
        public RetailOutlets(string name, List<string> nameProduct, Settings settings)
        {
            Name = name;
            _nameProduct = nameProduct;
            _settings = settings;
            _random = new Random();
        }
        /// <summary>
        /// Название магазина
        /// </summary>
        public string Name { get; set; }
        public string GetName()
        {
            return Name;
        }
        /// <summary>
        /// Виды доступных для заказа продуктов
        /// </summary>
        private List<string> _nameProduct;

        private Random _random;

        private Settings _settings;

        /// <summary>
        /// Выборка продукта для заказа 
        /// </summary>
        public Applications PreparationApplication()
        {
            List<string> TempProduct = new List<string>(_nameProduct);
            Applications applications = new Applications($"OOO\"{Name}\"", new Dictionary<string, int>());
            int idx;
            for (int i = _random.Next(10, 20); i >= 0; i--)
            {
                idx = _random.Next(0, TempProduct.Count);
                applications.Products[TempProduct[idx]] = _settings.StorageCapacityProduct / _random.Next(_settings.LowerNumberRangeRandom - 3, _settings.UpperNumberRangeRandom - 3);
                TempProduct.RemoveAt(idx);
            }            
            return applications;
        }        
    }
}
