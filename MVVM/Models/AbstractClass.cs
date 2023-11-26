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
    public abstract class Product : IComparable<Product>
    {
        /// <summary>
        /// 
        /// </summary>
        public byte Volume { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public uint Price { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ExpirationDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>

        public int CompareTo(Product other)
        {
            return ExpirationDate.CompareTo(other.ExpirationDate);
        }
    }
}
