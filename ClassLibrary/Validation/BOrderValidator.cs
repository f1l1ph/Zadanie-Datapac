using ClassLibrary.Entities;
using FluentValidation;

namespace ClassLibrary.Validation;

public class BOrderValidator:AbstractValidator<BorrowOrderEntity>
{
    public BOrderValidator()
    {
        RuleFor(x => x.User).NotEmpty().WithMessage("user cannot be null");
    }
}

