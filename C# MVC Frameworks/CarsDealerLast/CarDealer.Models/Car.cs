namespace CarDealer.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        public Car()
        {
            this.Parts = new HashSet<PartCars>();
            this.Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Make { get; set; }

        [Required]
        [MaxLength(50)]
        public string Model { get; set; }

        [Range(0, long.MaxValue)]
        public long TravelledDistance { get; set; }

        public virtual ICollection<PartCars> Parts { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
