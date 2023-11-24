﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAutomation.MVVM.Models
{
    public class Applications
    {
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
