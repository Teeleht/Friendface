using Friendface.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
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
            friendfaceRepository.ClearFriends();
        }

        public void ClearUsers()
        {
            friendfaceRepository.ClearUsers();
        }

        public bool AreFriends(int friendId, int userId)
        {
            return friendfaceRepository.GetFriendships().Any(x => x.UserA.Id == friendId && x.UserB.Id == userId || x.UserA.Id == userId && x.UserB.Id == friendId);
        }

        public User GetUser(int id)
        {
            return friendfaceRepository.GetUserById(id);
        }
        public User GetUser(string username)
        {
            return friendfaceRepository.GetActive().First(x => x.Username == username);
        }
    }
}
