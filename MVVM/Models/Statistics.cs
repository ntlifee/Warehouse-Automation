using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAutomation.MVVM.Models
{
    public class Statistics : IStatistics
    {
        public uint TotalApplications { get; set; }
        public uint CompletedApplications { get; set; }
        public uint RejectedApplications { get; set; }
        public uint WarehouseProfit { get; set; }
        public uint WarehouseLosses { get; set; }
    }
}
