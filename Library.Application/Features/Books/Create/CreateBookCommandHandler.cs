using FluentValidation;
using MediatR;

namespace Library.Application.Features.Books.Create;

public class CreateBookCommandHandler: IRequestHandler<CreateBookCommand, CreateBookResponse>
{
    private readonly IValidator<CreateBookCommand> _validator;

    public CreateBookCommandHandler(IValidator<CreateBookCommand> validator)
    {
        _validator = validator ?? throw new ArgumentNullException(nameof(validator));
    }

    public async Task<CreateBookResponse> Handle(CreateBookCommand command, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(command, cancellationToken);
        
        var book = new Book(command.Title, command.Author);
        await Task.FromResult(0);
        return new CreateBookResponse(book);
    }
}