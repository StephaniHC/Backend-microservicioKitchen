using NutritionalKitchen.Domain.KitchenManager;
using NutritionalKitchen.Domain.Package;
using NutritionalKitchen.Infraestructura;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseSentry();

// Add services to the container.
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Kitchen Nutrition Microservice",
        Version = "v2.0",
        Description = "API para administrar recetas, menus y requerimientos nutricionales. - NUR"
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();

app.UseSwaggerUI();


app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
