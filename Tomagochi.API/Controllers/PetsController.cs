using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tomagochi.BLL.DTO;
using Tomagochi.DAL.Entities;
using Tomagochi.DAL.Interfaces;
using FluentValidation.Results;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Tomagochi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IValidator<PetDTO> _validator;
        private readonly IPetRepository _petRepo;

        public PetsController(IPetRepository petRepo, IValidator<PetDTO> validator, IMapper mapper)
        {
            _petRepo = petRepo;
            _validator = validator;
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
            ValidationResult result = await _validator.ValidateAsync(petDTO);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState,null);
                return BadRequest(result);
            }

            var pet = _mapper.Map<Pet>(petDTO);
            _petRepo.CreatePet(pet);
            await _petRepo.SaveAsync();
            
            return CreatedAtAction(nameof(Create), new { id = pet.Id }, pet);
        }

        //public IActionResult CheckName(string name)
        //{
        //    if(_petRepo.HasEntity(p => p.Name == name))
        //    {
        //        return Json(false);
        //    }
        //    return Json(true);
        //}
    }
}
