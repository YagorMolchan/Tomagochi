using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tomagochi.BLL.DTO;
using Tomagochi.DAL.Entities;
using Tomagochi.DAL.Interfaces;

namespace Tomagochi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetRepository _petRepo;
        private readonly IMapper _mapper;

        public PetsController(IPetRepository petRepo, IMapper mapper)
        {
            _petRepo = petRepo;
            _mapper = mapper;
        }
        
        [HttpGet("Images")]
        public IActionResult Create()
        {
            PetDTO petDTO = new PetDTO();
            return Ok(petDTO);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PetDTO petDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if(_petRepo.HasEntity(p => p.Name == petDTO.Name))
            {
                ModelState.AddModelError(nameof(petDTO.Name), "The pet with the same name exists already!!!");
            }

            var pet = _mapper.Map<Pet>(petDTO);
            _petRepo.Create(pet);
            await _petRepo.SaveAsync();
            return CreatedAtAction(nameof(Create), new { id = pet.Id }, pet);

        }
    }
}
