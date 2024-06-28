using ClassLibrary.Entities;
using FluentValidation;

namespace ClassLibrary.Validation;

public class BOrderValidator:AbstractValidator<BorrowOrderEntity>
{
    public BOrderValidator()
    {
        RuleFor(x => x.User).NotEmpty().WithMessage("User cannot be null");
        RuleFor(x => x.CloseDate).NotEmpty().WithMessage("Close date cannot be empty");
        RuleFor(x => x.OpenDate).NotEmpty().WithMessage("Open date cannot be empty");
    }
}

