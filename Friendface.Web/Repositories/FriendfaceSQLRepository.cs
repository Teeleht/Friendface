using Friendface.Core;
using Friendface.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friendface.Web.Repositories
{
    public class FriendfaceSQLRepository : IFriendfaceRepository

    {
        private readonly FriendfaceContext context;

        public FriendfaceSQLRepository(FriendfaceContext context)
        {
            this.context = context;
        }

        public int CreateFriendship(User userA, User userB, DateTime added)
        {
            var friendship = new Friendship
            {
                UserA = userA,
                UserB = userB,
                Added = added,
            };

            context.Friendships.Add(friendship);
            context.SaveChanges();

            return friendship.Id;
        }

        public void DeleteFriendship(Friendship friendship)
        {
            context.Friendships.Remove(friendship);
            context.SaveChanges();
        }

        public int CreateUser(string username, string password, DateTime birthday, string description, string address, string email, string gender)
        {
            var user = new User
            {
                Username = username,
                Password = password,
                Birthday = birthday,
                Description = description,
                Address = address,
                Email = email,
                Gender = gender,

            };
            context.Users.Add(user);
            context.SaveChanges();

            return user.Id;
        }

        public List<User> GetActive()
        {
            return context.Users
                .Include(x => x.FriendshipsA)
                .Include(x => x.FriendshipsB)
                .Include(x => x.Posts).ThenInclude((Post x) => x.Comments)
                .Include(x => x.Comments)
                .ToList();
        }

        public List<Friendship> GetFriendships()
        {
            return context.Friendships
                .Include(x => x.UserA)
                .Include(x => x.UserB)
                .ToList();
        }

        public List<Post> GetPosts()
        {
            return context.Posts
                .Include(x => x.Author)
                .Include(x => x.Comments)
                .ToList();
        }

        public List<Comment> GetComments()
        {
            return context.Comments
                .Include(x => x.Post)
                .Include(x => x.Author)
                .ToList();
        }

        public void ClearFriends()
        {
            context.Friendships.RemoveRange(context.Friendships);
            context.SaveChanges();
        }

        public void ClearUsers()
        {
            context.Users.RemoveRange(context.Users);
            context.SaveChanges();
        }

        public User GetUserById(int id)
        {
            return context.Users.First(x => x.Id == id);
        }

        public void Update(int id, string username, string password, DateTime birthday, string description, string address, string email, string gender)
        {
            var user = context.Users.First(x => x.Id == id);

            user.Username = username;
            user.Password = password;
            user.Email = email;
            user.Address = address;
            user.Birthday = birthday;
            user.Description = description;
            user.Gender = gender;

            context.SaveChanges();
        }

        public int CreatePost(int userId, string content, string title, DateTime releaseDate)
        {
            var user = context.Users.First(x => x.Id == userId);
            var post = new Post
            {
                Author = user,
                AuthorId = userId,
                Content = content,
                ReleaseDate = releaseDate,
                Title = title,                
            };
            context.Posts.Add(post);
            context.SaveChanges();

            return post.Id;
        }

        public void DeletePost(Post post)
        {
            context.Remove(post);
            context.SaveChanges();
        }

        public int CreateComment(int userId, int postId, string content, DateTime releaseDate)
        {
            var author = context.Users.First(x => x.Id == userId);
            var post = context.Posts.First(x => x.Id == postId);

            var comment = new Comment
            {
                Author = author,
                Post = post,
                Content = content,
                ReleaseDate = releaseDate,
            };

            context.Comments.Add(comment);
            context.SaveChanges();

            return comment.Id;
        }
    }
}
