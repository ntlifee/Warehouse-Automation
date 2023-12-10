using DevExpress.Mvvm;
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
    public class Settings : BindableBase
    {
        /// <summary>
        /// Количество видов продуктов 
        /// </summary>
        public int NumberTypesProducts { get; set; } = 16;
        /// <summary>
        /// Количество торговых точек 
        /// </summary>
        public int NumberStores { get; set; } = 6;
        /// <summary>
        /// Количество дней моделирования
        /// </summary>
        public int NumberSimulationDays { get; set; } = 20;
        /// <summary>
        /// Вместимость склада для продуктов 
        /// </summary>
        public int StorageCapacityProduct { get; set; } = 75;
        /// <summary>
        /// Нижнее число диапазона случайных чисел
        /// </summary>
        public int LowerNumberRangeRandom { get; set; } = 5;
        /// <summary>
        /// Верхнее число диапазона случайных чисел
        /// </summary>
        public int UpperNumberRangeRandom { get; set; } = 10;
    }
}
