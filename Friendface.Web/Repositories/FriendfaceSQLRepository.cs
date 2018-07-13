using Friendface.Core;
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

        public int CreateUser(string username, string password, DateTime birthday, string description, string address, string email)
        {
            var user = new Core.Domain.User
            {
                Username = username,
                Password = password,
                Birthday = birthday,
                Description = description,
                Address = address,
                Email = email,
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
