using Microsoft.EntityFrameworkCore;
using skeleton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace skeleton.Data
{
    public class APIDbContext : DbContext
    {

        protected override void OnConfiguring
      (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "clientEmployee");
        }
        public DbSet<Client> Clients
        {
            get;
            set;
        }

        public DbSet<Employee> Employees
        {
            get;
            set;
        }
    }
}

