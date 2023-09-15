namespace DepositoHelados.Application.Services.CategoryService._03.Dtos;

public record BaseCategoryDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public int Sort { get; set; }
    public int CategoryParentId { get; set; }
}
