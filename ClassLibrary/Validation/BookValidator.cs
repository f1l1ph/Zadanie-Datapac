using ClassLibrary.Entities;
using FluentValidation;

namespace ClassLibrary.Validation;

public class BookValidator : AbstractValidator<BookEntity>
{
    public BookValidator()
    {
        RuleFor(x => x.Author).NotEmpty().WithMessage("no Author");
        RuleFor(x => x.Name).NotEmpty().WithMessage("no Name");
    }
}
