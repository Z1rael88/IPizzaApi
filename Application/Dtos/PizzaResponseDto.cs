using Infrastructure.Enums;
using Infrastructure.Models;

namespace Application.Dtos;

public class PizzaResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhotoUrl { get; set; }
    public decimal Price { get; set; }
    public ICollection<IngredientDto> Ingredients { get; set; }
    public PizzaSize Size { get; set; }
    public DoughType Dough { get; set; }
}