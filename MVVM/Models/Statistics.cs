using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAutomation.MVVM.Models
{
    /// <summary>
    /// Статистика 
    /// </summary>
    public class Statistics
    {
        /// <summary>
        /// День моделирования
        /// </summary>
        public static uint NumberDays { get; set; }
        /// <summary>
        /// Количество заявок
        /// </summary>
        public static uint TotalApplications { get; set; }
        /// <summary>
        /// Выполнено заявок 
        /// </summary>
        public static uint CompletedApplications { get; set; }
        /// <summary>
        /// Отклоненные заявки
        /// </summary>
        public static uint RejectedApplications { get; set; }
        /// <summary>
        /// Прибыль склада
        /// </summary>
        public static uint WarehouseProfit { get; set; }
        /// <summary>
        /// Складские потери
        /// </summary>
        public static uint WarehouseLosses { get; set; }
    }
}
