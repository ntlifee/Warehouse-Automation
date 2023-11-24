using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAutomation.MVVM.Models
{
    public class Statistics
    {
        public static uint NumberDays { get; set; }
        public static uint TotalApplications { get; set; }
        public static uint CompletedApplications { get; set; }
        public static uint RejectedApplications { get; set; }
        public static uint WarehouseProfit { get; set; }
        public static uint WarehouseLosses { get; set; }
    }
}
