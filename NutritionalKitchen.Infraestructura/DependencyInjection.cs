using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NutritionalKitchen.Application;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.Ingredients;
using NutritionalKitchen.Domain.KitchenManager;
using NutritionalKitchen.Domain.Package;
using NutritionalKitchen.Domain.Recipe;
using NutritionalKitchen.Infraestructura.DomainModel;
using NutritionalKitchen.Infraestructura.Repositories;
using NutritionalKitchen.Infraestructura.StoredModel;
using NutritionalKitchen.Infraestructura.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infraestructura
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment)
        {
            services.AddMediatR(config =>
                    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
                );
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<StoredDbContext>(context =>
                    context.UseMySql(connectionString,
                        ServerVersion.AutoDetect(connectionString)));
            services.AddDbContext<DomainDbContext>(context =>
            context.UseMySql(connectionString,
                        ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<IIngredientsRepository, IngredientsRepository>();
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<IKitchenManagerRepository, KitchenManagerRepository>();
            services.AddScoped<ILabelRepository, LabelRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAplication()
                .AddSecrets(configuration, environment)
                .AddRabbitMQ();

            return services;
        }
    }
}
