using Joseco.Communication.External.Contracts.Services;
using MediatR;
using NutritionalKitchen.Application.Package.CreatePackage;
using NutritionalKitchen.Integration.Package;

namespace NutritionalKitchen.Infraestructura.RabbitMQ.Consumers
{
    public class LabeledPackageConsumer(IMediator mediator) : IIntegrationMessageConsumer<LabeledPackage>
    {
        public async Task HandleAsync(LabeledPackage message, CancellationToken cancellationToken)
    {
        CreateIPackageCommand command = new(
            Guid.NewGuid(),
            "Pending",
            "",
            Guid.NewGuid()
        );
        await mediator.Send(command, cancellationToken);
    }
}
}
