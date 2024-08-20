using System.Reflection;
using FluentValidation;
using Library.Application.Features.Books.Create;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application;

public static class ApplicationBootstrapper
{
    public static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(config => 
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddScoped<IValidator<CreateBookCommand>, CreateBookCommandValidator>();
    }
    
}