using System.Net;
using System.Net.Http.Json;
using Library.ApiTests.Setup;
using Library.Application.Features.Books.Create;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Library.ApiTests.Books.Create;
[Collection("LibraryTests")]
public class GivenCreateBookCalledWhenRequestIsValid(LibraryTestApplicationFactory factory)
    : IAsyncLifetime
{
    private HttpClient _client = null!;
    private HttpResponseMessage _response = null!;
    private CreateBookResponse _responseContent = null!;
    private const string Title = "Test Book Title";
    private const string Author = "Test Author";

    
    public async Task InitializeAsync()
    {
        _client = factory.HttpClient;

        var command = new CreateBookCommand(Title, Author);
        _response = await _client.PostAsJsonAsync("/book" ,command);
        _responseContent = (await _response.Content.ReadFromJsonAsync<CreateBookResponse>())!;
    }

    public Task DisposeAsync() => Task.CompletedTask;

    [Fact]
    public void Then200CreatedResponseIsReturned()
    {
        _response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact]
    public void ThenResponseIsCorrect()
    {
        using (new AssertionScope())
        {
            _responseContent.Book.Author.Should().Be(Author);
            _responseContent.Book.Title.Should().Be(Title);
        }

    }
}