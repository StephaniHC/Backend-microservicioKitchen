using MediatR;
using NutritionalKitchen.Application.Ingredients.CreateIngredient;
using NutritionalKitchen.Domain.Abstractions;
using NutritionalKitchen.Domain.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.Ingredients.CreateIngredient
{
    public class CreateCommandHandler : IRequestHandler<CreateIngredientCommand, Guid>
    {
        private readonly IIngredientFactory _ingredientFactory;
        private readonly IIngredientsRepository _ingredientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommandHandler(IIngredientFactory ingredientFactory,
            IIngredientsRepository ingredientRepository,
            IUnitOfWork unitOfWork)
        {
            _ingredientFactory = ingredientFactory;
            _ingredientRepository = ingredientRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
        {
            var ingredient = _ingredientFactory.Create(request.id, request.name);

            await _ingredientRepository.AddAsync(ingredient);

            await _unitOfWork.CommitAsync(cancellationToken);

            return ingredient.Id;
        }
    }
}
