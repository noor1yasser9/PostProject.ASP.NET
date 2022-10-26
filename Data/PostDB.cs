using System;
using Microsoft.EntityFrameworkCore;
using PostProject.Models;

namespace PostProject.Data
{
    public class PostDB : DbContext
    {
        public PostDB(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Categories { get; set; }


    }
}

