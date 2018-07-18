using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Friendface.Core.Domain
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(50)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required")]
        [StringLength(1000)]
        public string Content { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
