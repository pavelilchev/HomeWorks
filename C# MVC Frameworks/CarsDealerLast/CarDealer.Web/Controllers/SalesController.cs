namespace CarDealer.Web.Controllers
{
    using CarDealer.Services;
    using Microsoft.AspNetCore.Mvc;

    public class SalesController : Controller
    {
        private readonly ISalesService sales;

        public SalesController(ISalesService sales)
        {
            this.sales = sales;
        }

        public IActionResult Index()
        {
            var allSales = this.sales.All();

            return View(allSales);
        }

        public IActionResult Details(int id)
        {
            var sale = this.sales.ById(id);

            return View(sale);
        }

        [Route("/Sales/discounted/{percent?}")]
        public IActionResult Discounted(double? percent)
        {
            var discountedSales = this.sales.ByDiscount(percent);

            return View("Index", discountedSales);
        }
    }
}
