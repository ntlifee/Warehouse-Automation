using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAutomation.MVVM.Models
{
    public class Product
    {
        public Product(string name, List<ProductParameter> parameters)
        {
            Name = name;
            Parameters = parameters;
        }
        public string Name { get; set; }
        public List<ProductParameter> Parameters { get; set; }
    }
}
