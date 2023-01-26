using FluentValidation;
using TestRestApiApp.Dto;

namespace TestRestApiApp.Validators
{
    public class EditDocumentRequestModelValidator:AbstractValidator<EditDocumentRequestModel>
    {
        public EditDocumentRequestModelValidator()
        {
            RuleFor(x=>x.Data).NotEmpty();
            
        }
    }
}
