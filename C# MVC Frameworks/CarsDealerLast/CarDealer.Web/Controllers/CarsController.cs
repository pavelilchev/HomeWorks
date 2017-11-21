namespace CarDealer.Web.Controllers
{
    using CarDealer.Services;
    using CarDealer.Web.Models.Cars;
    using Microsoft.AspNetCore.Mvc;

    [Route("cars")]
    public class CarsController : Controller
    {
        private readonly ICarsService cars;

        public CarsController(ICarsService cars)
        {
            this.cars = cars;
        }

        [Route("all")]
        public IActionResult All()
        {
            var carsByMake = this.cars.All();
           
            return View(carsByMake);
        }

        [Route("bymake/{make}")]
        public IActionResult ByMake(string make)
        {
            var carsByMake = this.cars.ByMake(make);

            var model = new CarsByMake
            {
                Make = make,
                Cars = carsByMake
            };

            return View(model);
        }
        
        [Route("parts")]
        public IActionResult Parts()
        {
            var cars = this.cars.AllWithParts();

            return View(cars);
        }
    }
}
