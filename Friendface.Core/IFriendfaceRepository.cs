using System;
using System.Collections.Generic;
using System.Text;

namespace Friendface.Core
{
    public interface IFriendfaceRepository
    {
        List<Domain.User> GetActive();

        int CreateUser(string username, string password, DateTime birthday, string description, string address, string email);
    }
}
