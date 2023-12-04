using DevExpress.Mvvm;
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
    public class Statistics : BindableBase
    {
        //public Statistics(uint NumberDays, uint TotalApplications, uint CompletedApplications, uint RejectedApplications, uint WarehouseProfit, uint WarehouseLosses)
        //{
                
        //}

        /// <summary>
        /// День моделирования
        /// </summary>
        public static uint NumberDays { get; set; }
        /// <summary>
        /// Количество заявок
        /// </summary>
        public uint TotalApplications { get; set; }
        /// <summary>
        /// Выполнено заявок 
        /// </summary>
        public uint CompletedApplications { get; set; }
        /// <summary>
        /// Отклоненные заявки
        /// </summary>
        public uint RejectedApplications { get; set; }
        /// <summary>
        /// Прибыль склада
        /// </summary>
        public int WarehouseProfit { get; set; }

        public void AddStatistics(Statistics statistics)
        {
            TotalApplications += statistics.TotalApplications;
            CompletedApplications += statistics.CompletedApplications;
            RejectedApplications += statistics.RejectedApplications;
            WarehouseProfit += statistics.WarehouseProfit;
        }
        public void ChangeStatistics(Statistics statistics)
        {
            TotalApplications = statistics.TotalApplications;
            CompletedApplications = statistics.CompletedApplications;
            RejectedApplications = statistics.RejectedApplications;
            WarehouseProfit = statistics.WarehouseProfit;
        }
    }
}
