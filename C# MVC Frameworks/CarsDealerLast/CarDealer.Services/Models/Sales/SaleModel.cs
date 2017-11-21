namespace CarDealer.Services.Models.Sales
{
    using CarDealer.Services.Models.Cars;

    public class SaleModel
    {
        public CarModel Car { get; set; }

        public CustomerModel Customer { get; set; }

        public decimal Price { get; set; }

        public double Discount { get; set; }
    }
}
