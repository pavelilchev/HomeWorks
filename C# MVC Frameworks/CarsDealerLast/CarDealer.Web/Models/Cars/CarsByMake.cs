namespace CarDealer.Web.Models.Cars
{
    using CarDealer.Services.Models.Cars;
    using System.Collections.Generic;

    public class CarsByMake
    {
        public string Make { get; set; }

        public IEnumerable<CarModel> Cars { get; set; }
    }
}
