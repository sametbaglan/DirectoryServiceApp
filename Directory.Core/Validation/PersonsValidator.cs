using Directory.Core.Dto.PersonsDtos;
using Directory.Core.Validation.ValidMessage;
using FluentValidation;

namespace Directory.Core.Validation
{
    public class PersonsValidator:AbstractValidator<PersonsDto>
    {
        public PersonsValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage(AllMessages.RequiredField); ;
            RuleFor(x => x.Surname).NotNull().WithMessage(AllMessages.RequiredField);
            RuleFor(x => x.Company).NotNull().WithMessage(AllMessages.RequiredField); ;
        }
    }
}
