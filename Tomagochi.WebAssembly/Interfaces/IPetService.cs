using Tomagochi.BLL.DTO;

namespace Tomagochi.WebAssembly.Interfaces
{
    public interface IPetService
    {
        Task<PetDTO> GetImages();

        Task CreatePet(PetDTO petDTO);
    }
}
