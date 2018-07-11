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

        public int Create(string name, DateTime birthday, string description)
        {
            var friend = new Core.Friendface
            {
                Name = name,
                Birthday = birthday,
                Description = description,
            };
            context.Friends.Add(friend);
            context.SaveChanges();

            return friend.Id;
        }

        public List<Core.Friendface> GetActive()
        {
            return context.Friends.ToList();
        }
    }
}
