using Vehicle.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vehicle.Api.Repository.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
    }
}
