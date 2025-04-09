using Error_Catalog_API___Multilingual_Lookup_Service.Data.ErrorCatalogApi.Data;
using Microsoft.EntityFrameworkCore;
using Error_Catalog_API___Multilingual_Lookup_Service.Data;
using Microsoft.OpenApi.Models;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Registrar el DbContext y configurar la cadena de conexión
        builder.Services.AddDbContext<ErrorCatalogDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ErrorCatalogDB"))
        );

        // Registrar los controladores
        builder.Services.AddControllers();

        // Agregar Swagger/OpenAPI
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Error Catalog API",
                Version = "v1",
                Description = "API to view error codes in English and Spanish.\n\n" +
                              "Note: The information has been sourced from learn.microsoft.com "
            });
        });

        var app = builder.Build();

        // Configurar SwaggerUI
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Error Catalog API V1");
            options.RoutePrefix = string.Empty; // Swagger será la página de inicio
        });

        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}