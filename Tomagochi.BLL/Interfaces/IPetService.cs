using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomagochi.BLL.DTO;

namespace Tomagochi.BLL.Interfaces
{
    public interface IPetService
    {
        Task<PetDTO> GetImages();

        Task CreatePet(PetDTO petDTO);
    }
}
