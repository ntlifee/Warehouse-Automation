using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAutomation.MVVM.Models
{
    public class Product : IProduct
    {
        public string Type { get; set; }
        public byte NumberPacks { get; set; }
        public byte Volume { get; set; }
        public uint Price { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
