namespace _4.ProductsMigration.Models
{
    using System;

    public class Sale
    {
        public int Id { get; set; }

        public virtual Product Product { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual StoreLocation StoreLocation { get; set; }

        public DateTime Date { get; set; }
    }
}
