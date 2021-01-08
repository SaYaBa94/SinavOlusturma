using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class DatabaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
           => options.UseSqlite("Data Source=TestProject.db");

        public DbSet<User> Users { get; set; }

        public DbSet<Test> Tests { get; set; }

        public DbSet<Question> Questions { get; set; }
    }
}
