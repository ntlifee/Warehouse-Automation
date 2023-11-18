using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAutomation.MVVM.Models
{
    public class Applications : IApplications
    {
        public string Name { get; set; }
        public Product product { get; set; }
    }
}
