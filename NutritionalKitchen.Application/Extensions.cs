using Microsoft.Extensions.DependencyInjection;
using NutritionalKitchen.Domain.Ingredients;
using NutritionalKitchen.Domain.KitchenManager;
using NutritionalKitchen.Domain.Package;
using NutritionalKitchen.Domain.Recipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddMediatR(config =>
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );
             
            services.AddSingleton<IRecipeFactory, RecipeFactory>();
            services.AddSingleton<IIngredientFactory, IngredientFactory>();
            services.AddSingleton<IKitchenManagerFactory, KitchenManagerFactory>();
            services.AddSingleton<IPackageFactory, PackageFactory>();
            services.AddSingleton<ILabelFactory, LabelFactory>();
            services.AddSingleton<IRecipeFactory, RecipeFactory>();


            return services;
        }

    }
}
