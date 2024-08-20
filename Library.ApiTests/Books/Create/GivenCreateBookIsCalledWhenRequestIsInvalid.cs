using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Library.ApiTests.Setup;
using Library.Application.Features.Books.Create;

namespace Library.ApiTests.Books.Create;
[Collection("LibraryTests")]
public class GivenCreateBookIsCalledWhenRequestIsInvalid(LibraryTestApplicationFactory factory): IAsyncLifetime
{
    private HttpClient _client = null!;
    public Task InitializeAsync()
    {
        _client = factory.CreateClient();
        return Task.CompletedTask;
    }

    public Task DisposeAsync() => Task.CompletedTask;

    [Fact]
    public async Task WhenNoTitleIsProvided_ThenReturnsBadRequest()
    {
        var command = new CreateBookCommand(Title: "", Author: "Author");
        var response = await _client.PostAsJsonAsync("/book", command);
        var responseContent = (await response.Content.ReadAsStringAsync())!;

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        responseContent.Should().Be("Title is required.");
    }
    
    [Fact]
    public async Task WhenNoAuthorIsProvided_ThenReturnsBadRequest()
    {
        var command = new CreateBookCommand(Title: "Title", Author: "");
        var response = await _client.PostAsJsonAsync("/book", command);
        var responseContent = (await response.Content.ReadAsStringAsync())!;

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        responseContent.Should().Be("Author is required.");
    }
}