﻿using Friendface.Core.Domain;
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
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasMany<Friendship>(x => x.Friendships);
            modelBuilder.Entity<Friendship>().HasOne<User>(x => x.UserA);
            modelBuilder.Entity<Friendship>().HasOne<User>(x => x.UserB);


        }

    }
}
