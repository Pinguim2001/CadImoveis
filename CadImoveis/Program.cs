
using Microsoft.EntityFrameworkCore;
using CadImoveis.Infrastructure.Persistence;
using CadImoveis.Domain.Interfaces;
using CadImoveis.Application.Services;
using CadImoveis.Infrastructure.Repositories;

namespace CadImoveis
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options =>  
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IProprietarioRepository, ProprietarioRepository>();
            builder.Services.AddScoped<IImovelRepository, ImovelRepository>();
            builder.Services.AddScoped<ImovelService>();
            builder.Services.AddScoped<CadastroService>();

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
