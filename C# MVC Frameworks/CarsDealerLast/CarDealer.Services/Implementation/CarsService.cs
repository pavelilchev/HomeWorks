namespace CarDealer.Services.Implementation
{
    using System.Collections.Generic;
    using CarDealer.Services.Models.Cars;
    using CarDealer.Data;
    using System.Linq;
    using CarDealer.Services.Models.Parts;

    public class CarsService : ICarsService
    {
        private readonly CarDealerDbContext db;

        public CarsService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CarModel> ByMake(string make)
        {
            return this.db
                 .Cars
                 .Where(c => c.Make == make)
                 .Select(c => new CarModel
                 {
                     Make = c.Make,
                     Model = c.Model,
                     TravelledDistance = c.TravelledDistance
                 })
                 .ToList();
        }

        public IEnumerable<CarModel> All()
        {
            return this.db
                 .Cars
                 .Select(c => new CarModel
                 {
                     Make = c.Make,
                     Model = c.Model,
                     TravelledDistance = c.TravelledDistance
                 })
                 .ToList();
        }

        public IEnumerable<CarWithPartsModel> AllWithParts()
        {
            return this.db
                .Cars
                .Select(c => new CarWithPartsModel
                {
                    Car = new CarModel
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    Parts = c.Parts.Select(p => new PartModel
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price.Value
                    })
                })
                .ToList();
        }
    }
}
