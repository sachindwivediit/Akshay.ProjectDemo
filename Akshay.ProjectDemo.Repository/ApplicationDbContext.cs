using Akshay.ProjectDemo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akshay.ProjectDemo.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 

        }
        public DbSet<Country> countries { get; set; }
        public DbSet<State> states { get; set; }
        public DbSet<City> cities { get; set; }
    }
}
