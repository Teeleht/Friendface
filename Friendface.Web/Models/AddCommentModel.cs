using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friendface.Web.Models
{
    public class AddCommentModel
    {
        public int PostId { get; set; }
        public string CommentContent { get; set; }
    }
}
