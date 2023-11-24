using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAutomation.MVVM.Models
{
    public abstract class Product : IComparable<Product>
    {
        public byte Volume { get; set; }
        public uint Price { get; set; }
        public DateTime ExpirationDate { get; set; }

        public int CompareTo(Product other)
        {
            return ExpirationDate.CompareTo(other.ExpirationDate);
        }
    }
}
