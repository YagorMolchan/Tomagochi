using System.ComponentModel.DataAnnotations;

namespace Tomagochi.API.Models.Requests
{
    public class RegisterRequest
    {
        [Display(Name ="First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public string ImagePath { get; set; }

        public IFormFile ImageFile { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email must be inputted!")]
        [DataType(DataType.EmailAddress, ErrorMessage = "The form of data is incorrect!")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password must be inputted!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Password must be confirmed!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password has been confirmed incorrectly!")]
        public string ConfirmedPassword { get; set; }
    }
}
