namespace _12.RemoveInactiveUsers.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Users
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public byte[] ProfilePicture { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }

        public int Age { get; set; }

        public bool IsDeleted { get; set; }
    }
}
