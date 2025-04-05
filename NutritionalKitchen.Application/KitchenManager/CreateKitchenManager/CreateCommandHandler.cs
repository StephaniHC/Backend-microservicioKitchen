using MediatR;
using NutritionalKitchen.Domain.Abstractions; 
using NutritionalKitchen.Domain.KitchenManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.KitchenManager.CreateKitchenManager
{ 
    public class CreateCommandHandler : IRequestHandler<CreateKitchenManagerCommand, Guid>
    {
        private readonly IKitchenManagerFactory _kitcheManagerFactory;
        private readonly IKitchenManagerRepository _kitcheManagerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommandHandler(IKitchenManagerFactory kitcheManagerFactory,
            IKitchenManagerRepository kitcheManagerRepository,
            IUnitOfWork unitOfWork)
        {
            _kitcheManagerFactory = kitcheManagerFactory;
            _kitcheManagerRepository = kitcheManagerRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateKitchenManagerCommand request, CancellationToken cancellationToken)
        {
            var kitchenManager = _kitcheManagerFactory.Create(request.id, request.name, request.shift);

            await _kitcheManagerRepository.AddAsync(kitchenManager);

            await _unitOfWork.CommitAsync(cancellationToken);

            return kitchenManager.Id;
        }
    }
}
