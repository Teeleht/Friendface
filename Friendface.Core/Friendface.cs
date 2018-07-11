using System;
using System.ComponentModel.DataAnnotations;

namespace Friendface.Core
{
    public class Friendface
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Birthday is required")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Birthday { get; set; }

        [StringLength(300)]
        public string Description { get; set; }


    }
}
