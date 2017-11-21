namespace CarDealer.Services.Implementation
{
    using System.Collections.Generic;
    using CarDealer.Services.Models.Sales;
    using CarDealer.Data;
    using System.Linq;
    using CarDealer.Services.Models.Cars;
    using CarDealer.Services.Models;

    public class SalesService : ISalesService
    {
        private readonly CarDealerDbContext db;

        public SalesService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SaleModel> All()
        {
            return this.db
                  .Sales
                  .Select(s => new SaleModel
                  {
                      Car = new CarModel
                      {
                          Make = s.Car.Make,
                          Model = s.Car.Model,
                          TravelledDistance = s.Car.TravelledDistance
                      },
                      Customer = new CustomerModel
                      {
                          Name = s.Customer.Name,
                          BirthDate = s.Customer.BirthDate,
                          IsYoungDriver = s.Customer.IsYoungDriver
                      },
                      Price = s.Car.Parts.Sum(p => p.Part.Price.Value),
                      Discount = s.Discount
                  })
                  .ToList();
        }

        public SaleModel ById(int id)
        {
            return this.db
                  .Sales
                  .Where(s => s.Id == id)
                  .Select(s => new SaleModel
                  {
                      Car = new CarModel
                      {
                          Make = s.Car.Make,
                          Model = s.Car.Model,
                          TravelledDistance = s.Car.TravelledDistance
                      },
                      Customer = new CustomerModel
                      {
                          Name = s.Customer.Name,
                          BirthDate = s.Customer.BirthDate,
                          IsYoungDriver = s.Customer.IsYoungDriver
                      },
                      Price = s.Car.Parts.Sum(p => p.Part.Price.Value),
                      Discount = s.Discount
                  })
                  .FirstOrDefault();
        }

        public IEnumerable<SaleModel> ByDiscount(double? discount = null)
        {
            var salesQuery = this.db
                  .Sales
                  .AsQueryable();

            if (discount != null)
            {
                salesQuery = salesQuery
                    .Where(s => s.Discount == discount.Value);
            }
            else
            {
                salesQuery = salesQuery
                   .Where(s => s.Discount > 0);
            }

           return salesQuery
                .Select(s => new SaleModel
                {
                    Car = new CarModel
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Customer = new CustomerModel
                    {
                        Name = s.Customer.Name,
                        BirthDate = s.Customer.BirthDate,
                        IsYoungDriver = s.Customer.IsYoungDriver
                    },
                    Price = s.Car.Parts.Sum(p => p.Part.Price.Value),
                    Discount = s.Discount
                })
                .ToList();
        }
    }
}
