using Infrastructure.Enums;

namespace Application.Dtos;

public class IngredientDto
{
    public string Name { get; set; }
    public IngredientType IngredientType { get; set; }
    public decimal Price { get; set; }
}