using BookAPI.BusinessLogicLayer.Services;
using BookAPI.BusinessLogicLayer.Services.Interfaces;
using BookAPI.Configuration;
using BookAPI.DataAccessLayer;
using BookAPI.DataAccessLayer.Repositories;
using BookAPI.DataAccessLayer.Repositories.Interfaces;
using BookAPI.Infrastracture;
using Microsoft.EntityFrameworkCore;

namespace BookAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureServices(builder.Services, builder.Configuration);

            var app = builder.Build();

            ConfigureApplication(app);
        }

        private static void ConfigureServices(IServiceCollection serviceCollection, ConfigurationManager configurationManager)
        {
            serviceCollection.AddControllers();
            serviceCollection.AddEndpointsApiExplorer();

            serviceCollection.AddSwaggerGen();
            serviceCollection.AddAutoMapper(cfg => cfg.AddProfile<BooksProfile>());

            serviceCollection.AddTransient<IBooksService, BooksService>();
            serviceCollection.AddTransient<IBooksRepository, BooksRepository>();
            serviceCollection.AddDbContext<BooksDbContext>(options => options.UseSqlServer(configurationManager.GetConnectionString("BookStorageDB"), b => b.MigrationsAssembly("BookAPI")));
        }

        private static void ConfigureApplication(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseExceptionHandler(new ExceptionHandlerOptions()
            { ExceptionHandler = new ExceptionHandlerMiddleware().Invoke });

            app.MapControllers();

            app.Run();
        }
    }
}