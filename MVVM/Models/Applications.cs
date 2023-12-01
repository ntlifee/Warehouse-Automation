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
        public Applications(string Name, Dictionary<string, int> products)
        {
            _name = Name;
            _products = products;
        }
        /// <summary>
        /// Название заказчика
        /// </summary>
        public string _name { get; set; }
        /// <summary>
        /// Тип и количество продуктов
        /// </summary>
        public Dictionary<string, int> _products { get; set; }
    }
}
