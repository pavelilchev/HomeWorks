namespace CarDealer.Web.Controllers
{
    using CarDealer.Services;
    using CarDealer.Services.Models.Suppliers;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class SuppliersController : Controller
    {
        private const string SuppliersViewName = "Suppliers";

        private readonly ISuppliersService suppliers;

        public SuppliersController(ISuppliersService suppliers)
        {
            this.suppliers = suppliers;
        }

        public IActionResult Local()
        {
            return View(SuppliersViewName, this.GetByType(false));
        }

        public IActionResult Importers()
        {
            return View(SuppliersViewName, this.GetByType(true));
        }

        private IEnumerable<SupplierModel> GetByType(bool isImporter)
        {
            return this.suppliers.All(isImporter);
        }
    }
}
