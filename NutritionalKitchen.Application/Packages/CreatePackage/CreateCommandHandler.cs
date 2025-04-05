using MediatR; 
using NutritionalKitchen.Domain.Abstractions; 
using NutritionalKitchen.Domain.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.Package.CreatePackage
{ 
    public class CreateCommandHandler : IRequestHandler<CreateIPackageCommand, Guid>
    {
        private readonly IPackageFactory _packageFactory;
        private readonly IPackageRepository _packageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommandHandler(IPackageFactory packageFactory,
            IPackageRepository packageRepository,
            IUnitOfWork unitOfWork)
        {
            _packageFactory = packageFactory;
            _packageRepository = packageRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateIPackageCommand request, CancellationToken cancellationToken)
        {
            var package = _packageFactory.Create(request.id, request.status, request.BatchCode, request.preparedRecipeId);

            await _packageRepository.AddAsync(package);

            await _unitOfWork.CommitAsync(cancellationToken);

            return package.Id;
        }
    }
} 