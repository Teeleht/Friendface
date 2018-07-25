using System;
using System.Collections.Generic;
using System.Text;

namespace Friendface.Core.Domain
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public User Author { get; set; }
        public Post Post { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
