using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAutomation.MVVM.Models
{
    public class ProductWarehouse : Product
    {
        public byte NumberPacks { get; set; }
    }

    public class ProductRetail : Product
    {

    }
}
