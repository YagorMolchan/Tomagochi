using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomagochi.DAL.Entities;

namespace Tomagochi.DAL.EFCore
{
    public class TomagochiDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Pet> Pets { get; set; }

        public TomagochiDbContext(DbContextOptions<TomagochiDbContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .Property(u => u.UserName)
                .HasComputedColumnSql("FirstName + ' ' + LastName", stored: true);
        }
    }
}
