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
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("author", "Me"),
                new KeyValuePair<string, string>("name", "")
            });

            var response = await _client.PostAsync("/Books", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Put_BookData_NoContent()
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("author", "Me"),
                new KeyValuePair<string, string>("name", "Book")
            });

            var response = await _client.PostAsync("/Books/2", content);

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task Put_InvalidBookData_BadRequest()
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("author", "Me"),
                new KeyValuePair<string, string>("name", "")
            });

            var response = await _client.PostAsync("/Books/3", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Put_BookDataWithWrongId_NotFound()
        {
            var content = new FormUrlEncodedContent(new[]
{
                new KeyValuePair<string, string>("author", "Me"),
                new KeyValuePair<string, string>("name", "Book")
            });

            var response = await _client.PostAsync("/Books/100", content);

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
