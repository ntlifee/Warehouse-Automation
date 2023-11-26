using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAutomation.MVVM.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductWarehouse : Product
    {
        public byte NumberPacks { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ProductRetail : Product
    {

    }
}
