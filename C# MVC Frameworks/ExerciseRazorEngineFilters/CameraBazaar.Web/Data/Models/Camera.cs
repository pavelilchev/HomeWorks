namespace CameraBazaar.Web.Data.Models
{
    using CameraBazaar.Web.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;

    public class Camera
    {
        public int Id { get; set; }

        public CameraMake Make { get; set; }

        [Required]
        [RegularExpression("[A-Z0-9-]")]
        public string Model { get; set; }

        public decimal Price { get; set; }

        [Range(0, 100)]
        public int Quantity { get; set; }

        [Range(0, 30)]
        public int MinShutterSpeed { get; set; }

        [Range(2000, 8000)]
        public int MazShutterSpeed { get; set; }

        public MinISO MinISO { get; set; }

        [Range(200, 409600)]
        public int MaxISO { get; set; }

        public bool IsFullFrame { get; set; }

        [MaxLength(15)]
        public string VideoResolution { get; set; }

        public LightMetering LightMetering { get; set; }

        [MaxLength(6000)]
        public string Description { get; set; }

        [RegularExpression(@"^(http:\/\/|https:\/\/).{3,2000}")]
        public string ImageURL { get; set; }
    }
}
