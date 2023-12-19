using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAutomation.MVVM.Models.Interfaces
{
    public interface ICreateWarehouse
    {
        Warehouse Warehouse(Settings settings, Statistics statistics, List<string> _nameProduct);
    }
}
