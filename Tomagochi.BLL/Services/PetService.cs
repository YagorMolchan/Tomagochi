using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Tomagochi.BLL.Interfaces;
using Tomagochi.BLL.DTO;

namespace Tomagochi.BLL.Services
{
    public class PetService:IPetService
    {
        private readonly HttpClient _client;

        private readonly JsonSerializerOptions _options;

        public PetService(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task CreatePet(PetDTO petDTO)
        {
            var content = JsonSerializer.Serialize(petDTO);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var postResult = await _client.PostAsync("Pets", bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();

            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }

        }

        public async Task<PetDTO> GetImages()
        {
            var response = await _client.GetAsync("Pets/Images");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            var petDto = JsonSerializer.Deserialize<PetDTO>(content, _options);
            return petDto;
        }
    }
}
