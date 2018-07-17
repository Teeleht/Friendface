using Friendface.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friendface.Web.Models
{
    public class IndexModel
    {
        public User User { get; set; }
        public IEnumerable<Friendship> Friendships { get; set; }
    }
}
