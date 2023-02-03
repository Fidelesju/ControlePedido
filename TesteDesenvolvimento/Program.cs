using TesteDesenvolvimento.Business.Mappers;
using TesteDesenvolvimento.Business.Mappers.Interfaces;
using TesteDesenvolvimento.Business.Services;
using TesteDesenvolvimento.Business.Services.Interfaces;
using TesteDesenvolvimento.Data.Dao;
using TesteDesenvolvimento.Data.Dao.Interfaces;
using TesteDesenvolvimento.Data.Repositories;
using TesteDesenvolvimento.Data.Repositories.Interfaces;

namespace TesteDesenvolvimento
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Injection Dependency Service
            builder.Services.AddScoped<IClienteService, ClienteService>();
            builder.Services.AddScoped<IPedidoService, PedidoService>();
            builder.Services.AddScoped<IItensPedidoService, ItensPedidoService>();

            //Injection dependecy mapper
            builder.Services.AddScoped<IClienteCreateMapper, ClienteCreateMapper>();
            builder.Services.AddScoped<IPedidoCreateMapper, PedidoCreateMapper>();
            builder.Services.AddScoped<IItemPedidoCreateMapper, ItemPedidoCreateMapper>();

            //Injection dependecy repository
            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
            builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
            builder.Services.AddScoped<IItemPedidoRepository, ItemPedidoRepository>();

            //Injection dependecy db
            builder.Services.AddScoped<IClienteDb, ClienteDb>();
            builder.Services.AddScoped<IPedidoDb, PedidoDb>();
            builder.Services.AddScoped<IItensPedidoDb, ItensPedidoDb>();

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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