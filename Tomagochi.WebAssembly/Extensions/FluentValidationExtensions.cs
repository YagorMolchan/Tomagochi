using Microsoft.AspNetCore.Components.Forms;
using FluentValidation;
using FluentValidation.Internal;
using System.ComponentModel.DataAnnotations;

namespace Tomagochi.WebAssembly.Extensions
{
    public static class FluentValidationExtensions
    {
        private readonly static char[] separators = { '.', '[' };

        public static EditContext AddFluentValidation(this EditContext editContext, IServiceProvider serviceProvider, IValidator validator)
        {
            if(editContext == null)
            {
                throw new ArgumentNullException(nameof(editContext));
            }

            var messages = new ValidationMessageStore(editContext);

            editContext.OnValidationRequested += (sender, eventArgs) => ValidateModel((EditContext)sender, messages, serviceProvider, validator);
            editContext.OnFieldChanged += (sender, eventArgs) => ValidateField(editContext, messages, eventArgs.FieldIdentifier, serviceProvider, validator);

            return editContext;
        }

        private static async void ValidateModel(EditContext editContext, ValidationMessageStore messages, IServiceProvider serviceProvider, IValidator validator)
        {
            if(validator == null)
            {
                validator = GetValidatorForModel(serviceProvider, editContext.Model);
            }

            var validationResults = await validator.ValidateAsync((IValidationContext)editContext.Model);

            messages.Clear();

            foreach(var validationResult in validationResults.Errors)
            {
                var fieldIdentifier = ToFieldIdentifier(editContext, validationResult.PropertyName);
                messages.Add(fieldIdentifier, validationResult.ErrorMessage);
            }

            editContext.NotifyValidationStateChanged();
        }

        private static async void ValidateField(EditContext editContext, ValidationMessageStore messages, FieldIdentifier fieldIdentifier, IServiceProvider serviceProvider, IValidator validator)
        {
            var properties = new[] { fieldIdentifier.FieldName };

            var context = new FluentValidation.ValidationContext<object>(fieldIdentifier.Model, new PropertyChain(), new MemberNameValidatorSelector(properties));

            validator = validator ?? GetValidatorForModel(serviceProvider, editContext.Model);

            if (validator != null)
            {
                var validatorResult = await validator.ValidateAsync(context);
                messages.Clear(fieldIdentifier);
                messages.Add(fieldIdentifier, validatorResult.Errors.Select(v => v.ErrorMessage));
                editContext.NotifyValidationStateChanged();
            }
        }

        private static IValidator GetValidatorForModel(IServiceProvider serviceProvider, object model)
        {
            var validatorType = typeof(IValidator<>).MakeGenericType(model.GetType());
            if (serviceProvider != null)
            {
                var objValidator = serviceProvider.GetService(validatorType);

                if(serviceProvider.GetService(validatorType) is IValidator validator)
                {
                    return validator;
                }
            }

            var abstractValidatorType = typeof(AbstractValidator<>).MakeGenericType(model.GetType());
            Type modelValidatorType = null;

            foreach(var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                modelValidatorType = assembly.GetTypes().FirstOrDefault(x => x.IsSubclassOf(abstractValidatorType));
                if (modelValidatorType != null)
                    break;
            }

            if (modelValidatorType == null)
                return null;

            return (IValidator)ActivatorUtilities.CreateInstance(serviceProvider, modelValidatorType);
        }

        private static FieldIdentifier ToFieldIdentifier(EditContext editContext, string propertyPath)
        {
            var obj = editContext.Model;

            while (true)
            {
                var nextTokenEnd = propertyPath.IndexOfAny(separators);
                if (nextTokenEnd < 0)
                    return new FieldIdentifier(obj, propertyPath);
                var nextToken = propertyPath.Substring(0, nextTokenEnd);
                propertyPath = propertyPath.Substring(nextTokenEnd + 1);

                object newObj;

                if (nextToken.EndsWith("]"))
                {
                    nextToken = nextToken.Substring(0, nextToken.Length - 1);
                    var prop = obj.GetType().GetProperty("Item");
                    var indexerType = prop.GetIndexParameters()[0].ParameterType;
                    var indexerValue = Convert.ChangeType(nextToken, indexerType);
                    newObj = prop.GetValue(obj, new object[] { indexerValue });
                }
                else
                {
                    var prop = nextToken.GetType().GetProperty(nextToken);
                    if (prop == null)
                        throw new InvalidOperationException("Invalid property name");
                    newObj = prop.GetValue(obj);
                }

                if (newObj == null)
                    return new FieldIdentifier(obj, nextToken);

                obj = newObj;
            }

        }
    }
}
