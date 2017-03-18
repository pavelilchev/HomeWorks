namespace BookshopSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Book
    {
        private ICollection<Category> categories;
        private ICollection<Book> relatedBooks;

        public Book()
        {
            this.categories = new HashSet<Category>();
            this.relatedBooks = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Title should be between 1 and 50 characters long")]
        public string Title { get; set; }

        [MaxLength(1000, ErrorMessage = "Description should be less than 1000 characters long")]
        public string Description { get; set; }

        public EditionType EditionType { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        [Range(0, double.PositiveInfinity)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Copies { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public virtual ICollection<Category> Categories
        {
            get
            {
                return this.categories;
            }
            set
            {
                this.categories = value;

            }
        }
        public virtual ICollection<Book> RelatedBooks
        {
            get
            {
                return this.relatedBooks;
            }
            set
            {
                this.relatedBooks = value;

            }
        }
    }

    public enum EditionType
    {
        Normal,
        Promo,
        Gold
    }

    public enum AgeRestriction
    {
        Minor,
        Teen,
        Adult
    }
}
