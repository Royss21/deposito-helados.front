using MediatR;

namespace DepositoHelados.Application.Services.ProductService.Dtos;


public record CreateProductDto : IRequest<bool>
{
    public int MdBrandId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
