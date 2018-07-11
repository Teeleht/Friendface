using System;
using System.Collections.Generic;
using System.Text;

namespace Friendface.Core
{
    public interface IFriendfaceRepository
    {
        int Create(string name, DateTime birthday, string description);
        List<Friendface> GetActive();
    }
}
