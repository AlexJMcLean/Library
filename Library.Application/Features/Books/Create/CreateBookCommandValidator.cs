using FluentValidation;

namespace Library.Application.Features.Books.Create;

internal class CreateBookCommandValidator: AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(p => p.Title).NotEmpty().WithMessage("{PropertyName} is required.").NotNull();
        RuleFor(p => p.Author).NotEmpty().WithMessage("{PropertyName} is required.").NotNull();
    }
}