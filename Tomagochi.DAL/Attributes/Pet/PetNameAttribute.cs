using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Tomagochi.DAL.EFCore;

namespace Tomagochi.DAL.Attributes.Pet
{
    public class PetNameAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var context = (TomagochiDbContext)validationContext.GetService(typeof(TomagochiDbContext));

            if(!context.Pets.Any(p => p.Name == value.ToString()))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("The pet with the same name exists already");
        }
    }
}
