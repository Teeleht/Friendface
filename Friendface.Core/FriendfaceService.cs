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

        public IEnumerable<Post> GetPosts()
        {
            return friendfaceRepository.GetPosts();
        }

        public void CreateUser(string username, string password, DateTime birthday, string description, string address, string email, string gender)
        {
            var allUsers = friendfaceRepository.GetActive();

            if (allUsers.Any(x => x.Username == username))
            {
                throw new Exception("Username already exists");
            }
            else
            {
                friendfaceRepository.CreateUser(username, password, birthday, description, address, email, gender);
            }
        }

        public void CreateFriendship(User userA, User userB, DateTime added)
        {
            friendfaceRepository.CreateFriendship(userA, userB, added);
        }

        public void DeleteFriendship(User userA, User userB)
        {
            var friendships = friendfaceRepository.GetFriendships().FindAll(x => x.UserA == userA && x.UserB == userB || x.UserA == userB && x.UserB == userA);

            foreach (var friendship in friendships)
            {
                friendfaceRepository.DeleteFriendship(friendship);
            }            
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

        public void ChangeProfile(int id, string username, string password, DateTime birthday, string description, string address, string email, string gender)
        {
            friendfaceRepository.Update(id, username, password, birthday, description, address, email, gender);
        }

        public void CreatePost(int userId, string content, string title, DateTime releaseDate)
        {
            friendfaceRepository.CreatePost(userId, content, title, releaseDate);
        }

        public void DeletePost(Post post)
        {
            friendfaceRepository.DeletePost(post);
        }
        public IEnumerable<Comment> ShowComments()
        {
            return friendfaceRepository.GetComments();
        }

        public void CreateComment(int userId, int postId, string content, DateTime releaseDate)
        {
            friendfaceRepository.CreateComment(userId, postId, content, releaseDate);
        }
    }

}
