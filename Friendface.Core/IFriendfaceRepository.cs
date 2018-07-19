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
        void DeleteFriendship(Friendship friendship);
        List<Friendship> GetFriendships();
        List<Post> GetPosts();
        void ClearFriends();
        void ClearUsers();
        User GetUserById(int id);
        void Update(int id, string username, string password, DateTime birthday, string description, string address, string email, string gender);
        int CreatePost(int userId, string content, string title, DateTime releaseDate);
        void DeletePost(Post post);
        int CreateComment(int userId, int postId, string content);
        List<Comment> GetComments();

    }
}
