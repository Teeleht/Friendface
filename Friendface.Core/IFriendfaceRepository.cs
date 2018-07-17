using Friendface.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Friendface.Core
{
    public interface IFriendfaceRepository
    {
        List<User> GetActive();
        int CreateUser(string username, string password, DateTime birthday, string description, string address, string email, string gender);
        int CreateFriendship(User userA, User userB, DateTime added);

        List<Friendship> GetFriendships();
        void Clear();
    }
}
