namespace CarDealer.Services
{
    using CarDealer.Services.Models.Sales;
    using System.Collections.Generic;

    public interface ISalesService
    {
        IEnumerable<SaleModel> All();

        SaleModel ById(int id);

        IEnumerable<SaleModel> ByDiscount(double? discount = null);
    }
}
