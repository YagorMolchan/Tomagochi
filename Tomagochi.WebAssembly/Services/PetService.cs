using Tomagochi.BLL.DTO;
using Tomagochi.WebAssembly.Interfaces;
using System.Text.Json;
using System.Text;

namespace Tomagochi.WebAssembly.Services
{
    public class PetService : IPetService
    {
        private readonly IHttpClientFactory _httpFactory;
        private readonly JsonSerializerOptions _jsonOptions;

        public PetService(IHttpClientFactory httpFactory)
        {
            _httpFactory = httpFactory;
            _jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task CreatePet(PetDTO petDTO)
        {
            var content = JsonSerializer.Serialize(petDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var client = _httpFactory.CreateClient("TomagochiClient");
            var postResult = await client.PostAsync("Pets", bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
        }

        public async Task<PetDTO> GetImages()
        {
            var client = _httpFactory.CreateClient("TomagochiClient");
            var response = await client.GetAsync("Pets/Images");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var petDto = JsonSerializer.Deserialize<PetDTO>(content, _jsonOptions);
            return petDto;
        }
    }
}
