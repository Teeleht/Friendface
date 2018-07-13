﻿using Friendface.Core;
using Friendface.Core.Domain;
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

        public List<Core.Domain.User> GetActive()
        {
            return context.Users.ToList();
        }
    }
}
