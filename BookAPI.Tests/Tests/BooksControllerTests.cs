using BookAPI.Common.Models.DTO;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text.Json;
using Xunit;

namespace BookAPI.Tests.Tests
{
    public class BooksControllerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;
        private readonly HttpClient _client;

        public BooksControllerTests(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions { AllowAutoRedirect = false });
        }

        [Fact]
        public async Task Get_NoParameters_OK()
        {
            var response = await _client.GetAsync("/Books/");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Get_IdOfExistingBook_OK()
        {
            var response = await _client.GetAsync("/Books/1");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Get_IdOfNonExistingBook_NotFound()
        {
            var response = await _client.GetAsync("/Books/100");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Post_BookData_Created()
        {
            var stringContent = new StringContent(JsonSerializer.Serialize(new BookCreateDto() { Author = "Me", Name = "Book" }));
            stringContent.Headers.ContentType = new("application/json");
            var response = await _client.PostAsync("/Books", stringContent);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task Post_InvalidBookData_BadRequest()
        {
            var stringContent = new StringContent(JsonSerializer.Serialize(new BookCreateDto() { Author = "Me", Name = "" }));
            stringContent.Headers.ContentType = new("application/json");
            var response = await _client.PostAsync("/Books", stringContent);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Put_BookData_NoContent()
        {
            var stringContent = new StringContent(JsonSerializer.Serialize(new BookCreateDto() { Author = "Me", Name = "Book" }));
            stringContent.Headers.ContentType = new("application/json");
            var response = await _client.PutAsync("/Books/2", stringContent);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task Put_InvalidBookData_BadRequest()
        {
            var stringContent = new StringContent(JsonSerializer.Serialize(new BookCreateDto() { Author = "Me", Name = "" }));
            stringContent.Headers.ContentType = new("application/json");
            var response = await _client.PutAsync("/Books/3", stringContent);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Put_BookDataWithWrongId_NotFound()
        {
            var stringContent = new StringContent(JsonSerializer.Serialize(new BookCreateDto() { Author = "Me", Name = "Book" }));
            stringContent.Headers.ContentType = new("application/json");
            var response = await _client.PutAsync("/Books/100", stringContent);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Delete_IdOfExistingBook_NoContent()
        {
            var response = await _client.DeleteAsync("/Books/4");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task Delete_IdOfNonExistingBook_NotFound()
        {
            var response = await _client.DeleteAsync("/Books/100");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
