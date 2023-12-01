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
        //public Statistics(uint NumberDays, uint TotalApplications, uint CompletedApplications, uint RejectedApplications, uint WarehouseProfit, uint WarehouseLosses)
        //{
                
        //}

        /// <summary>
        /// День моделирования
        /// </summary>
        public uint _numberDays { get; set; }
        /// <summary>
        /// Количество заявок
        /// </summary>
        public uint _totalApplications { get; set; }
        /// <summary>
        /// Выполнено заявок 
        /// </summary>
        public uint _completedApplications { get; set; }
        /// <summary>
        /// Отклоненные заявки
        /// </summary>
        public uint _rejectedApplications { get; set; }
        /// <summary>
        /// Прибыль склада
        /// </summary>
        public int _warehouseProfit { get; set; }

        public void AddStatistics(Statistics statistics)
        {
            _numberDays = statistics._numberDays;
            _totalApplications += statistics._totalApplications;
            _completedApplications += statistics._completedApplications;
            _rejectedApplications += statistics._rejectedApplications;
            _warehouseProfit += statistics._warehouseProfit;
        }
    }
}
