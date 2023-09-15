namespace DepositoHelados.Application.Services.CategoryService._03.Dtos;

public record UpdateCategoryDto : BaseCategoryDto, IRequest<bool>
{
    public int Id { get; set; }
}
