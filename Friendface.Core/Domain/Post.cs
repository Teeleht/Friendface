using System;
using System.Collections.Generic;
using System.Text;

namespace Friendface.Core.Domain
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int AuthorId { get; set; }
        public User Author { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
