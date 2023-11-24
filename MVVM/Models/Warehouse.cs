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
        /// <summary>
        /// Общая вместимость склада
        /// </summary>
        public uint CapacityWarehouse { get; set; }
        /// <summary>
        /// Количество продуктов на складе
        /// </summary>
        public uint CountProduct { get; set; }
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
            Dictionary<string, List<Product>> products = new Dictionary<string, List<Product>>();
            foreach (var product in application.Products)
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
            }
            return products;
        }
        public Applications PreparationApplication()
        {
            Applications applications = new Applications();
            applications.Name = "OOO\"Склад\"";
            foreach (var product in Products)
            {
                if (product.Value.Count < 10)
                {
                    applications.Products[product.Key] = Settings.StorageCapacityProduct - product.Value.Count;
                }
            }
            return applications;
        }
        public void WriteOffProducts()
        {
            foreach (var product in Products)
            {
                product.Value.Sort();
                while (product.Value.Last().ExpirationDate.CompareTo(DateTime.Now.AddDays(Statistics.NumberDays)) <= 0)
                {
                    product.Value.RemoveAt(product.Value.Count - 1);
                }
            }
        }
    }
}
