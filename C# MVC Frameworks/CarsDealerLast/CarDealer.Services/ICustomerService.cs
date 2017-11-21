namespace CarDealer.Services
{
    using CarDealer.Services.Models;
    using CarDealer.Services.Models.Customers;
    using System.Collections.Generic;

    public interface ICustomerService
    {
        IEnumerable<CustomerModel> OrderedCustomers(bool asc);

        CustomerSalesModel SalesById(int id);
    }
}
