using MediatR;
using NutritionalKitchen.Domain.Abstractions; 
using NutritionalKitchen.Domain.Package;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.Label.CreateLabel
{
    public class CreateCommandHandler : IRequestHandler<CreateLabelCommand, Guid>
    {
        private readonly ILabelFactory _labelFactory;
        private readonly ILabelRepository _labelRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommandHandler(ILabelFactory labelFactory,
            ILabelRepository labelRepository,
            IUnitOfWork unitOfWork)
        {
            _labelFactory = labelFactory;
            _labelRepository = labelRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateLabelCommand request, CancellationToken cancellationToken)
        {
            var label = _labelFactory.Create(request.BatchCode, request.ProductionDate, request.ExpirationDate, request.Detail, request.Address, request.PatientId);

            await _labelRepository.AddAsync(label);

            await _unitOfWork.CommitAsync(cancellationToken);

            return label.BatchCode;
        }
    }
}
