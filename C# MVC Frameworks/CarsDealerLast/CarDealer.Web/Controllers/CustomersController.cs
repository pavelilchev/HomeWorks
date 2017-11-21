namespace CarDealer.Web.Controllers
{
    using CarDealer.Services;
    using Microsoft.AspNetCore.Mvc;

    public class CustomersController : Controller
    {
        private readonly ICustomerService customers;

        public CustomersController(ICustomerService customers)
        {
            this.customers = customers;
        }

        [Route("customers/all/{order}")]
        public IActionResult All(string order)
        {
            var asc = order.ToLower() == "ascending" ? true : false;

            var result = this.customers.OrderedCustomers(asc);

            return this.View(result);
        }

        public IActionResult Details(int id)
        {
            var customer = this.customers.SalesById(id);

            return View(customer);
        }
    }
}
