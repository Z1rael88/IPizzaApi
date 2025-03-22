using Infrastructure.Enums;

namespace Infrastructure.Models;

public class Ingredient : BaseModel
{
    public string Name { get; set; }
    public IngredientType IngredientType { get; set; }
    public decimal Price { get; set; }
}