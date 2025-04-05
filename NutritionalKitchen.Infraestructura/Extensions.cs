using NutritionalKitchen.Application;
using Microsoft.Extensions.DependencyInjection;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.Ingredients;
using NutritionalKitchen.Infraestructura.StoredModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using NutritionalKitchen.Infraestructura.Repositories;
using NutritionalKitchen.Infraestructura.DomainModel;
using Microsoft.EntityFrameworkCore;
using NutritionalKitchen.Domain.Package;
using NutritionalKitchen.Domain.KitchenManager;
using NutritionalKitchen.Domain.Recipe;

namespace NutritionalKitchen.Infraestructura
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
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

            services.AddAplication();

            return services;
        }
    }
}
