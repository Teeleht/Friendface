using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Friendface.Web.Models
{
    public class ChangeProfileModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Birthday { get; set; }

        [StringLength(300)]
        public string Description { get; set; }
        public string Address { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Gender { get; set; }
    }
}
