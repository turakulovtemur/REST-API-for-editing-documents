using FluentValidation;
using TestRestApiApp.Dto;

namespace TestRestApiApp.Validators
{
    public class DocumentRequstModelValidator : AbstractValidator<DocumentRequestModel>
    {
        public DocumentRequstModelValidator()
        {
            RuleFor(x=> x.Data).NotEmpty();
        }
    }
}
