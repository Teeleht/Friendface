using Friendface.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Friendface.Core
{
    public class FriendfaceService
    {
        private IFriendfaceRepository friendfaceRepository;

        public FriendfaceService(IFriendfaceRepository friendfaceRepository)
        {
            this.friendfaceRepository = friendfaceRepository;
        }

        public IEnumerable<User> ShowList()
        {
            return friendfaceRepository.GetActive();
        }

        public IEnumerable<Friendship> ShowFriendships()
        {
            return friendfaceRepository.GetFriendships();
        }

        public void CreateUser(string username, string password, DateTime birthday, string description, string address, string email, string gender)
        {
            friendfaceRepository.CreateUser(username, password, birthday, description, address, email, gender);
        }

        public void CreateFriendship(User userA, User userB, DateTime added)
        {
            friendfaceRepository.CreateFriendship(userA, userB, added);
        }

        public void ClearFriends()
        {
            friendfaceRepository.Clear();
        }
    }
}
