
using Microsoft.EntityFrameworkCore;
using TeamChallengeProject_Shop.Data;
using TeamChallengeProject_Shop.Data.Services;
using TeamChallengeProject_Shop.Data.Services.IServices;
using TeamChallengeProject_Shop.Services;
using TeamChallengeProject_Shop.Services.IServices;

namespace TeamChallengeProject_Shop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaulConnection"));
            });

            builder.Services.AddScoped<IStoreDataService, StoreDataService>();
            builder.Services.AddScoped<IStoreService, StoreService>();
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
