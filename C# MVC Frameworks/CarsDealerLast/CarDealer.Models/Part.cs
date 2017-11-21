namespace CarDealer.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Part
    {
        public Part()
        {
            this.Cars = new HashSet<PartCars>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public decimal? Price { get; set; }

        public int Quantity { get; set; }

        public virtual ICollection<PartCars> Cars { get; set; }

        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }
    }
}
