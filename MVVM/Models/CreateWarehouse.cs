using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAutomation.MVVM.Models.Interfaces;

namespace WarehouseAutomation.MVVM.Models
{
    public class CreateWarehouse : ICreateWarehouse
    {
        private Random _random = new Random();
        /// <summary>
        /// Занесение типов продуктов на склад и его пополнение 
        /// </summary>
        public Warehouse Warehouse(Settings settings, Statistics statistics, List<string> _nameProduct)
        {
            Warehouse warehouse = new Warehouse(settings, statistics);
            warehouse.Products = new List<Product>();
            List<string> TempProduct = new List<string>(_nameProduct);
            int idx;
            for (int i = 0; i < settings.NumberTypesProducts; i++)
            {
                idx = _random.Next(0, TempProduct.Count);
                warehouse.Products.Add(new Product(TempProduct[idx], new List<ProductParameter>()));
                TempProduct.RemoveAt(idx);
            }
            warehouse.OrderingProductsWarehouse();
            return warehouse;
        }
    }
}