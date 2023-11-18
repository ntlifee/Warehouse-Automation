using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAutomation.MVVM.Models
{
    public class Warehouse : IWarehouse
    {
        public uint CapacityWarehouse { get; set; }
        public uint CountProduct { get; set; }
        public List<Product> Products { get; set; }
    }
}
