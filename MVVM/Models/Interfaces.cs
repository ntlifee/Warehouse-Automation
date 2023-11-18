using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseAutomation.MVVM.Models
{
    public interface IProduct
    {
        string Type { get; set; }
        byte NumberPacks { get; set; }
        byte Volume { get; set; }
        uint Price { get; set; }
        DateTime ProductionDate { get; set; }            
        DateTime ExpirationDate { get; set; }
    }

    public interface ISettings
    {
        int NumberTypesProducts { get; set; }
        int NumberStores {  get; set; }
        int NumberSimulationDays { get; set; }
        int StorageCapacityProduct {  get; set; }

    }
    public interface IRetailOutlets
    {
        string Name { get; set; }
        List<Product> Products { get; set; }
    }
    public interface IStatistics
    {
        uint TotalApplications { get; set; }
        uint CompletedApplications { get; set; }
        uint RejectedApplications {  get; set; }
        uint WarehouseProfit { get; set; }
        uint WarehouseLosses { get; set; }
    }
    public interface IWarehouse
    {
        uint CapacityWarehouse {  get; set; }
        uint CountProduct {  get; set; }
        List<Product> Products { get; set; }
    }
    public interface IApplications
    {
        string Name { get; set; }
        Product product { get; set; }
    }
}
