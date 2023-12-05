using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAutomation.MVVM.Models
{
    /// <summary>
    /// Заявка 
    /// </summary>
    public class Applications
    {
        public Applications(string name, Dictionary<string, int> products)
        {
            Name = name;
            Products = products;
        }
        /// <summary>
        /// Название заказчика
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Тип и количество продуктов
        /// </summary>
        public Dictionary<string, int> Products { get; set; }
    }
}
