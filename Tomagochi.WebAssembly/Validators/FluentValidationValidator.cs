using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using FluentValidation;
using Tomagochi.WebAssembly.Extensions;

namespace Tomagochi.WebAssembly.Validators
{
    public class FluentValidationValidator:ComponentBase
    {
        [Inject]
        IServiceProvider ServiceProvider { get; set; }

        [CascadingParameter]
        EditContext CurrentEditContext { get; set; }

        [Parameter]
        public IValidator Validator { get; set; }

        protected override void OnInitialized()
        {
            if(CurrentEditContext == null)
            {
                throw new InvalidOperationException($"Invalid Edit Context");
            }
            CurrentEditContext.AddFluentValidation(ServiceProvider, Validator);
        }
    }
}
