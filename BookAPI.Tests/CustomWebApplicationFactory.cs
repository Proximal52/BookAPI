using BookAPI.Common.Models;
using BookAPI.DataAccessLayer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BookAPI.Tests
{
    public class CustomWebApplicationFactory<TStartup>
    : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<BooksDbContext>));

                services.Remove(descriptor);

                var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

                services.AddDbContext<BooksDbContext>(o => o.UseInMemoryDatabase(myDatabaseName));

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<BooksDbContext>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    db.Database.EnsureCreated();

                    try
                    {
                        db.Books.Add(new Book() { Author = "Me", Name = "Cool Book" });
                        db.Books.Add(new Book() { Author = "Not Me", Name = "Good Book" });
                        db.Books.Add(new Book() { Author = "Not Me", Name = "Cool Book" });
                        db.Books.Add(new Book() { Author = "Not Me", Name = "Not cool Book" });
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred seeding the " +
                            "database with test messages. Error: {Message}", ex.Message);
                    }
                }
            });
        }
    }
}
