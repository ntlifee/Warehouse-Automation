using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAutomation.MVVM.Models
{
    public class Settings : ISettings
    {
        private int _numberTypesProducts;

        public int NumberTypesProducts
        {
            get { return _numberTypesProducts; }
            set { _numberTypesProducts = value; }
        }

        private int _numberStores;

        public int NumberStores
        {
            get { return _numberStores; }
            set { _numberStores = value; }
        }

        private int _numberSimulationDays;

        public int NumberSimulationDays
        {
            get { return _numberSimulationDays; }
            set { _numberSimulationDays = value; }
        }

        private int _storageCapacityProduct;

        public int StorageCapacityProduct
        {
            get { return _storageCapacityProduct; }
            set { _storageCapacityProduct = value; }
        }
    }
}
