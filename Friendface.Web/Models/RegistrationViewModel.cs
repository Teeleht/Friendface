using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friendface.Web.Models
{
    public class RegistrationViewModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
    }
}
