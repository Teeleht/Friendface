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
        public DbSet<Core.Domain.User> Users { get; set; }
        public DbSet<Core.Domain.Post> Posts { get; set; }
        public DbSet<Core.Domain.Comment> Comments { get; set; }
    }
}
