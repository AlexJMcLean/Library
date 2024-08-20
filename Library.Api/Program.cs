using System.Net;
using Library.Application;
using Library.Application.Features.Books.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ApplicationBootstrapper.AddServices(builder.Services, builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/book", 
    (IMediator mediator, [FromBody] CreateBookCommand command) => mediator.Send(command))
    .ProducesValidationProblem()
    .Produces<CreateBookResponse>((int)HttpStatusCode.OK);

app.Run();

public partial class Program { }