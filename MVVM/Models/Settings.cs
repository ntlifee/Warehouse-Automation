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
        public Settings()
        {
                
        }
        public Settings(int NumberTypesProducts, int NumberStores, int NumberSimulationDays, int StorageCapacityProduct, int LowerNumberRangeRandom, int UpperNumberRangeRandom)
        {
            _numberTypesProducts = NumberTypesProducts;
            _numberStores = NumberStores;
            _numberSimulationDays = NumberSimulationDays;
            _storageCapacityProduct = StorageCapacityProduct;
            _lowerNumberRangeRandom = LowerNumberRangeRandom;
            _upperNumberRangeRandom = UpperNumberRangeRandom;
        }
        /// <summary>
        /// Количество видов продуктов 
        /// </summary>
        public int _numberTypesProducts { get; set; }
        /// <summary>
        /// Количество торговых точек 
        /// </summary>
        public int _numberStores { get; set; }
        /// <summary>
        /// Количество дней моделирования
        /// </summary>
        public int _numberSimulationDays { get; set; }
        /// <summary>
        /// Вместимость склада для продуктов 
        /// </summary>
        public int _storageCapacityProduct { get; set; }
        /// <summary>
        /// Нижнее число диапазона случайных чисел
        /// </summary>
        public int _lowerNumberRangeRandom { get; set; }
        /// <summary>
        /// Верхнее число диапазона случайных чисел
        /// </summary>
        public int _upperNumberRangeRandom { get; set; }
    }
}
