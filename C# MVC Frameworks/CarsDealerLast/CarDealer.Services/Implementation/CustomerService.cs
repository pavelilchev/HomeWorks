namespace CarDealer.Services
{
    using System.Collections.Generic;
    using CarDealer.Services.Models;
    using CarDealer.Data;
    using System.Linq;
    using CarDealer.Services.Models.Customers;

    public class CustomerService : ICustomerService
    {
        private readonly CarDealerDbContext db;

        public CustomerService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CustomerModel> OrderedCustomers(bool asc)
        {
            var custmersQuesry = this.db.Customers.AsQueryable();

            if (asc)
            {
                custmersQuesry = custmersQuesry
                    .OrderBy(c => c.BirthDate)
                    .ThenBy(c => c.Name);
            }
            else
            {
                custmersQuesry = custmersQuesry
                    .OrderByDescending(c => c.BirthDate)
                    .ThenBy(c => c.Name);
            }

            return custmersQuesry
                    .Select(c => new CustomerModel
                    {
                        Name = c.Name,
                        BirthDate = c.BirthDate,
                        IsYoungDriver = c.IsYoungDriver
                    })
                    .ToList();
        }

        public CustomerSalesModel SalesById(int id)
        {
            return this.db
                .Customers
                .Where(C => C.Id == id)
                .Select(c => new CustomerSalesModel
                {
                    Name = c.Name,
                    CarsCount = c.Sales.Count,
                    TotalMoney = c.Sales.Sum(s=>s.Car.Parts.Sum(p => p.Part.Price.Value))
                })
                .FirstOrDefault();
        }
    }
}
