namespace CarDealer.Services
{
    using CarDealer.Services.Models.Suppliers;
    using System.Collections.Generic;

    public interface ISuppliersService
    {
        IEnumerable<SupplierModel> All(bool isImporter);
    }
}
