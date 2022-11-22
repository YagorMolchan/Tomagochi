using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomagochi.DAL.Entities;

namespace Tomagochi.DAL.EFCore
{
    public class TomagochiDbContext:IdentityDbContext<User>
    {
        public DbSet<Pet> Pets { get; set; }

        public TomagochiDbContext(DbContextOptions<TomagochiDbContext> options) :base(options)
        {

        }
    }
}
