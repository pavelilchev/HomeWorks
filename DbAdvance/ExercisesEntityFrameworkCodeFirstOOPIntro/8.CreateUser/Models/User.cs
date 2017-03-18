namespace _8.CreateUser.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(30, MinimumLength = 4)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{6,50}")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^[a-zA-Z0-9][a-zA-Z0-9_.-]+[a-zA-Z0-9]@[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9].[a-zA-Z0-9-.]+$")]
        [DataType(DataType.EmailAddress)]
        public string Email  { get; set; }


        [MaxLength(1024 * 1024)]
        public byte[] ProfilePicture { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }

        [Range(1,120)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }
    }
}
