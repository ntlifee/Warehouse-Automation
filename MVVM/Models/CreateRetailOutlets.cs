using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAutomation.MVVM.Models.Interfaces;

namespace WarehouseAutomation.MVVM.Models
{
    public class CreateRetailOutlets : ICreateRetailOutlets
    {
        /// <summary>
        /// Создание магазинов
        /// </summary>
        public List<IRetailOutlets> RetailOutlets(Settings settings, List<string> _nameProduct)
        {
            List<IRetailOutlets> retailOutlets = new List<IRetailOutlets>();
            for (int i = 1; i <= settings.NumberStores; i++)
            {
                retailOutlets.Add(new RetailOutlets($"Магазин #{i}", _nameProduct, settings));
            }
            return retailOutlets;
        }
    }
}