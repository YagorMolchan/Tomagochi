using Microsoft.AspNetCore.Mvc;
using Tomagochi.DAL.Interfaces;
using Tomagochi.WEB.Models.Forms;

namespace Tomagochi.WEB.Controllers
{
    public class PetsController : Controller
    {
        private readonly IPetRepository _petRepo;

        public PetsController(IPetRepository petRepo)
        {
            _petRepo = petRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            PetFormModel model = new PetFormModel();
            return View(model);
        }

        
        [HttpPost]
        public IActionResult Create(PetFormModel model)
        {
            if (ModelState.IsValid)
            {
                
            }
            return View(model);
        }

        //[HttpPost]
        //public IActionResult Create(PetFormModel model)
        //{
        //    return View(model);
        //}
    }
}
