using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomagochi.DAL.Entities;

namespace Tomagochi.DAL.Interfaces
{
    public interface IPetRepository:IRepositoryBase<Pet>
    {
        IEnumerable<Pet> Pets { get;  }

        void CreatePet(Pet pet);

    }
}
