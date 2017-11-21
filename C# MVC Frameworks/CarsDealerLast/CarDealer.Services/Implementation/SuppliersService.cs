namespace CarDealer.Services.Implementation
{
    using System.Collections.Generic;
    using CarDealer.Services.Models.Suppliers;
    using CarDealer.Data;
    using System.Linq;

    public class SuppliersService : ISuppliersService
    {
        private readonly CarDealerDbContext db;

        public SuppliersService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SupplierModel> All(bool isImporter)
        {
            return db.Suppliers
                 .Where(s => s.IsImporter == isImporter)
                 .Select(s => new SupplierModel
                 {
                     Id = s.Id,
                     Name = s.Name,
                     PartsCount = s.Parts.Count
                 })
                 .ToList();
        }
    }
}
