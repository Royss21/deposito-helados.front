
using DepositoHelados.Application.Services.ProductService.Dtos;
using DepositoHelados.Application.Services.ProductService.Validators;
using DepositoHelados.Domain.Entities.ProductAggregate;

namespace DepositoHelados.Application.Services.ProductService.Commands.CreateProduct;

internal class CreateProductCommand : BaseHandler, IRequestHandler<CreateProductDto, bool>
{
    public CreateProductCommand(IUnitOfWork unitOfWork, IMapper  mapper) 
        : base(unitOfWork, mapper)
    { }

    public async Task<bool> Handle(CreateProductDto request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);

        var resultValidator = await _unitOfWork
            .Repository
            .ProductRepository
            .ValidateEntityAsync(product, new CreateProductValidator());

        if (!resultValidator.IsValid)
            throw new ValidatorException(string.Join(",", resultValidator.Errors.Select(e => e.ErrorMessage)));

        await _unitOfWork
                .Repository
                .ProductRepository
                .AddAsync(product);

        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}

