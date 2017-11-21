namespace CarDealer.Services.Models.Cars
{
    using CarDealer.Services.Models.Parts;
    using System.Collections.Generic;

    public class CarWithPartsModel
    {
        public CarModel Car { get; set; }

        public IEnumerable<PartModel> Parts { get; set; }
    }
}
