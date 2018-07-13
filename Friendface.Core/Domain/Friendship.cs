using System;
using System.Collections.Generic;
using System.Text;

namespace Friendface.Core.Domain
{
    public class Friendship
    {
        public int Id { get; set; }
        public User UserA { get; set; }
        public User UserB { get; set; }
        public DateTime Added { get; set; }
    }
}
