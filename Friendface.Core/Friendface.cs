using System;
using System.ComponentModel.DataAnnotations;

namespace Friendface.Core
{
    public class Friendface
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Description { get; set; }
    }
}
