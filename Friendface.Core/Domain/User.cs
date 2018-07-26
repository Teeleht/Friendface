using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Friendface.Core.Domain
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Birthday is required")]
        public DateTime Birthday { get; set; }

        [StringLength(300)]
        public string Description { get; set; }
        public string Address { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        public string Gender { get; set; }
        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
        public ICollection<Friendship> FriendshipsA { get; set; }
        public ICollection<Friendship> FriendshipsB { get; set; }
        public IEnumerable<Friendship> Friendships => FriendshipsA?.Concat(FriendshipsB);
    }
}
