using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAutomation.MVVM.Models
{
    public class RetailOutlets : IRetailOutlets
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
