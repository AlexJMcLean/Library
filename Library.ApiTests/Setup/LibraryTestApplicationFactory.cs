using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace Library.ApiTests.Setup;

public class LibraryTestApplicationFactory : WebApplicationFactory<Program>, IAsyncLifetime
{
    public HttpClient HttpClient { get; private set; } = null!; 
    public async Task InitializeAsync()
    {
        await Task.Run(() => HttpClient = CreateClient());
    }

    Task IAsyncLifetime.DisposeAsync() => DisposeAsync().AsTask();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestServices(services =>
        {
            // add mocked DI services here
            return;
        });
    }

    protected override void ConfigureClient(HttpClient client)
    {
        base.ConfigureClient(client);
        // client.DefaultRequestHeaders.Add("Api-Key", "Key"),
    }
}