using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAutomation.MVVM.Models
{
    /// <summary>
    /// Продукты
    /// </summary>
    public class Product
    {
        public Product()
        {
                
        }
        public Product(byte volume, uint priceBuy, uint priceSell, DateTime expirationDate)
        {
            Volume = volume;
            PriceBuy = priceBuy;
            PriceSell = priceSell;
            ExpirationDate = expirationDate;
        }
        /// <summary>
        /// Объем
        /// </summary>
        public byte Volume { get; set; }
        /// <summary>
        /// Цена покупки
        /// </summary>
        public uint PriceBuy { get; set; }
        /// <summary>
        /// Цена продажи
        /// </summary>
        public uint PriceSell { get; set; }
        /// <summary>
        /// Срок годности
        /// </summary>
        public DateTime ExpirationDate { get; set; }
    }
}