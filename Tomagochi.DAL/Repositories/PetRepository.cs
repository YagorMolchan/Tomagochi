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
    public class PetRepository : RepositoryBase<Pet>, IPetRepository
    {
        private readonly TomagochiDbContext _dbContext;

        public PetRepository(TomagochiDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Pet> Pets { get => GetAll(); }

        public void CreatePet(Pet pet)
        {
            Create(pet);
        }
        
    }
}
