using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAutomation.MVVM.Models
{
    /// <summary>
    /// Настройки 
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Количество типо продуктов 
        /// </summary>
        public static int NumberTypesProducts { get; set; }
        /// <summary>
        /// Количество торговых точек 
        /// </summary>
        public static int NumberStores { get; set; }
        /// <summary>
        /// Количество дней моделирования
        /// </summary>
        public static int NumberSimulationDays { get; set; }
        /// <summary>
        /// Вместимость склада для продуктов 
        /// </summary>
        public static int StorageCapacityProduct { get; set; }
    }
}
