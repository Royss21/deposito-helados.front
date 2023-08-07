using DepositoHelados.Domain.Entities.ProductAggregate;
using FluentValidation;

namespace DepositoHelados.Application.Services.ProductService.Validators;

internal class CreateProductValidator : AbstractValidator<Product>
{    
    public CreateProductValidator()
    {
        RuleFor(product => product.Name)
            .NotEmpty()
            .WithMessage("El Nombre es obligatorio")
            .NotNull()
            .WithMessage("El Nombre es obligatorio");

        RuleFor(product => product.MdBrandId)
            .NotEmpty()
            .WithMessage("Debe seleccionar una Marca")
            .NotNull()
            .WithMessage("Debe seleccionar una Marca");
    }    
}

