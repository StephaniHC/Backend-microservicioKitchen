using Microsoft.Extensions.DependencyInjection;
using Joseco.Communication.External.RabbitMQ;
using Joseco.Communication.External.RabbitMQ.Services;
using NutritionalKitchen.Infraestructura.RabbitMQ.Consumers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NutritionalKitchen.Integration.Package;

namespace NutritionalKitchen.Infraestructura.Extensions
{
    public static class BrokerExtensions
    {
        public static IServiceCollection AddRabbitMQ(this IServiceCollection services)
        {
            using var serviceProvider = services.BuildServiceProvider();
            var rabbitMqSettings = serviceProvider.GetRequiredService<RabbitMqSettings>();

            services.AddRabbitMQ(rabbitMqSettings)
                .AddRabbitMqConsumer<LabeledPackage, LabeledPackageConsumer>("kitchen-performed");

            return services;
        }
    }
}
