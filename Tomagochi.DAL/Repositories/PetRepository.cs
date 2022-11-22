using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomagochi.DAL.EFCore;
using Tomagochi.DAL.Entities;
using Tomagochi.DAL.Interfaces;

namespace Tomagochi.DAL.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly TomagochiDbContext _dbContext;

        public PetRepository(TomagochiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Pet> Pets { get => _dbContext.Pets.ToList(); }

        public void Create(Pet pet)
        {
            _dbContext.Pets.Add(pet);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
