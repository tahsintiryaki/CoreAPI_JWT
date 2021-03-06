using JWT_Example.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT_Example.DbContexts
{
    public class AppDbContext : DbContext
    {


        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
    }
}
