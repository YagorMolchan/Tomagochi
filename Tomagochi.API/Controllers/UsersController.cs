using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tomagochi.DAL.Interfaces;
using Tomagochi.API.Models.Requests;

namespace Tomagochi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepo, IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            _userRepo = userRepo;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
        }




        private async Task<string> UploadImage(RegisterRequest request)
        {
            string uniqueFileName = null;

            if (request.ImageFile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + request.ImageFile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await request.ImageFile.CopyToAsync(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
