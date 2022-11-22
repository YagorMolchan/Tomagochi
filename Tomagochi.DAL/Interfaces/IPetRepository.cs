using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomagochi.DAL.Entities;

namespace Tomagochi.DAL.Interfaces
{
    public interface IPetRepository
    {
        List<Pet> Pets { get;  }

        void Create(Pet pet);

        void Save();
    }
}
