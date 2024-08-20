using Library.Application.Features.Books.Create;
using MediatR;

namespace Library.Application.Features.Books.Create;

public record CreateBookCommand(string Title, string Author) : IRequest<CreateBookResponse>;