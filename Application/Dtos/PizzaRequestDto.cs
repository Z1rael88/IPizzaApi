using Infrastructure.Enums;
using Infrastructure.Models;

namespace Application.Dtos;

public class PizzaRequestDto
{
    public string Name { get; set; }
    public string PhotoUrl { get; set; }
    public decimal Price { get; set; }
    public ICollection<int> IngredientsIds { get; set; }
    public PizzaSize Size { get; set; }
    public DoughType Dough { get; set; }
}