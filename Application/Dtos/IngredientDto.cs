using Infrastructure.Enums;

namespace Application.Dtos;

public class IngredientDto
{
    public required int Id { get; set; }
    public string Name { get; set; }
    public IngredientType IngredientType { get; set; }
    public decimal Price { get; set; }
}