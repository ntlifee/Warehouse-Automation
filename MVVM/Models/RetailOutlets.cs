using System;
using System.Collections.Generic;

namespace WarehouseAutomation.MVVM.Models
{
    /// <summary>
    /// Торговые точки 
    /// </summary>
    public class RetailOutlets
    {        
        public RetailOutlets(string name, List<string> nameProduct, Settings settings)
        {
            Name = name;
            NameProduct = nameProduct;
            Settings = settings;
        }
        /// <summary>
        /// Название магазина
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Виды доступных для заказа продуктов
        /// </summary>
        private List<string> NameProduct;

        private Random Random = new Random();

        private Settings Settings;

        /// <summary>
        /// Выборка продукта для заказа 
        /// </summary>
        public Applications PreparationApplication()
        {
            List<string> TempProduct = new List<string>(NameProduct);
            Applications applications = new Applications($"OOO\"{Name}\"", new Dictionary<string, int>());
            int idx;
            for (int i = 0; i < Random.Next(0, 20); i++)
            {
                idx = Random.Next(0, TempProduct.Count);
                applications._products[TempProduct[idx]] = Random.Next(0, Settings.StorageCapacityProduct / Random.Next(Settings.LowerNumberRangeRandom, Settings.UpperNumberRangeRandom));
                TempProduct.RemoveAt(idx);
            }            
            return applications;
        }        
    }
}
