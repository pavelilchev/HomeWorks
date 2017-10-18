namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+<>])[A-Za-z\d!@#$%^&*()_+<>]{6,50}")]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"(?!.*\.\.)(^[^\.][^@\s]+@[^@\s]+\.[^@\s\.]+$)")]
        public string Email { get; set; }

        [MaxLength(1024)]
        public byte[] ProfilePicture { get; set; }

        public DateTime RegistredOn { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }

        public bool IsDeleted { get; set; }

        public List<UserFriend> FriendsFirst { get; set; } = new List<UserFriend>();

        public List<UserFriend> FriendsSecond { get; set; } = new List<UserFriend>();

        public List<Album> Albums { get; set; } = new List<Album>();
    }
}
