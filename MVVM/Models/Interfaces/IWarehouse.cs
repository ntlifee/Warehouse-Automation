using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAutomation.MVVM.Models.Interfaces
{
    public interface IWarehouse
    {
        List<Product> ApplicationProcessing(Applications application);
        void OrderingProductsWarehouse();
        void WriteOffProducts();
    }
}
