using DepositoHelados.Application.Services.CategoryService._03.Dtos;
using DepositoHelados.Application.Services.ProductService.Validators;
using DepositoHelados.Domain.Entities.CategoryAggregate;

namespace DepositoHelados.Application.Services.CategoryService._01.Commands.CreateCategory;

internal class CreateCategoryCommandHandler : BaseHandler, IRequestHandler<CreateCategoryDto, bool>
{
    public CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        : base(unitOfWork, mapper)
    { }

    public async Task<bool> Handle(CreateCategoryDto request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Category>(request);

        //var resultValidator = await _unitOfWork
        //    .Repository
        //    .ProductRepository
        //    .ValidateEntityAsync(category, new CreateProductValidator());

        //if (!resultValidator.IsValid)
        //    throw new ValidatorException(string.Join(",", resultValidator.Errors.Select(e => e.ErrorMessage)));

        await _unitOfWork
            .Repository
            .CategoryRepository
            .AddAsync(category);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}
