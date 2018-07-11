using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Friendface.Web.Repositories
{
    public class FriendfaceContext: DbContext
    {
        public FriendfaceContext(DbContextOptions<FriendfaceContext> options)
               : base(options)
        {
        }

        public DbSet<Core.Friendface> Friends { get; set; }
    }
}
