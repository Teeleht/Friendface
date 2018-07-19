using Friendface.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friendface.Web.Models
{
    public class DetailModel
    {
        public User User { get; set; }
        public bool IsFriend { get; set; }
        public bool IsMe { get; set; }
    }
}
