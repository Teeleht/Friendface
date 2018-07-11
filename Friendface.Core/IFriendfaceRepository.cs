using System;
using System.Collections.Generic;
using System.Text;

namespace Friendface.Core
{
    public interface IFriendfaceRepository
    {
        List<Friendface> GetActive();
    }
}
