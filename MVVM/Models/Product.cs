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
        public Product(byte Volume, uint PriceBuy, uint PriceSell, DateTime ExpirationDate)
        {
            _volume = Volume;
            _priceBuy = PriceBuy;
            _priceSell = PriceSell;
            _expirationDate = ExpirationDate;
        }
        /// <summary>
        /// Объем
        /// </summary>
        public byte _volume { get; set; }
        /// <summary>
        /// Цена покупки
        /// </summary>
        public uint _priceBuy { get; set; }
        /// <summary>
        /// Цена продажи
        /// </summary>
        public uint _priceSell { get; set; }
        /// <summary>
        /// Срок годности
        /// </summary>
        public DateTime _expirationDate { get; set; }
    }
}