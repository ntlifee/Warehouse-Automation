using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAutomation.MVVM.Models
{
    public class RetailOutlets
    {
        Random Random = new Random();
        /// <summary>
        /// Название магазина
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Key - тип продукта, Value - список продуктов
        /// </summary>
        public Dictionary<string, List<Product>> Products { get; set; }
        public void ApplicationProcessing(Dictionary<string, List<Product>> products)
        {
            foreach (var productName in products.Keys)
            {
                Products[productName].AddRange(products[productName]);
            }

        }
        public Applications PreparationApplication()
        {
            Applications applications = new Applications();
            applications.Name = $"OOO\"{Name}\"";
            foreach (var product in Products)
            {
                if (product.Value.Count < 10)
                {
                    applications.Products[product.Key] = 20 - product.Value.Count;
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
        public void Sales()
        {
            for (int i = Random.Next(0, Products.Count); i >= 0; i--)
            {
                for (int j = Random.Next(0, Products.Values.Count); j >= 0; j--)
                {
                    Products.ElementAt(i).Value.RemoveAt(Random.Next(0, Products.ElementAt(i).Value.Count));
                }
            }
        }
    }
}
