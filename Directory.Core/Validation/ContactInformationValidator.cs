using Directory.Core.Dto.ContactInformationDtos;
using Directory.Core.Validation.ValidMessage;
using FluentValidation;

namespace Directory.Core.Validation
{
    public class ContactInformationValidator : AbstractValidator<ContactInformationDto>
    {
        public ContactInformationValidator()
        {
            RuleFor(x => x.InfoContent).NotNull().WithMessage(AllMessages.RequiredField);
            RuleFor(x => x.InfoContent).NotNull().WithMessage(AllMessages.RequiredField);
            RuleFor(x => x.personid).GreaterThan(0).WithMessage("Please enter a staff id greater than 0");
        }
    }
}
