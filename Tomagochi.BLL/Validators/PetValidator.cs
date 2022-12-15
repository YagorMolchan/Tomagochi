using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomagochi.BLL.DTO;
using Tomagochi.DAL.Entities;

namespace Tomagochi.BLL.Validators
{
    public class PetValidator:AbstractValidator<PetDTO>
    {
        private IEnumerable<Pet> _pets;

        public PetValidator(IEnumerable<Pet> pets)
        {
            _pets = pets;
            RuleFor(p => p.Name).NotNull().NotEmpty()
                .WithMessage("The name of the pet must be inputted!");

            RuleFor(p => p.Name).Must(IsNameUnique)
                .WithMessage("The pet with the same name exists already!");

        }

        public bool IsNameUnique(PetDTO editedPet, string newValue)
        {
            return _pets.All(pet =>
              pet.Equals(editedPet) || pet.Name != newValue);
        }


    }
}
