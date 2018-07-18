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
            return context.Users.ToList();
        }

        public List<Friendship> GetFriendships()
        {
            return context.Friendships
                .Include(x => x.UserA)
                .Include(x => x.UserB)
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

        public void Update(User user)
        {
            var u = context.Users.First(x => x.Id == user.Id);

            u.Username = user.Username;
            u.Password = user.Password;
            u.Email = user.Email;
            u.Address = user.Address;
            u.Birthday = user.Birthday;
            u.Description = user.Description;
            u.Gender = user.Gender;           
        }

    }
}
