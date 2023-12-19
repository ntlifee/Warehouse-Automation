using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAutomation.MVVM.Models.Interfaces
{
    public interface IRetailOutlets
    {
        string GetName();
        Applications PreparationApplication();
    }
}
