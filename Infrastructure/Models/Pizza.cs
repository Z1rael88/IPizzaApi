using Infrastructure.Enums;

namespace Infrastructure.Models;

public class Pizza : BaseModel
{
    public string Name { get; set; }
    public string PhotoUrl { get; set; }
    public decimal Price { get; set; }
    public ICollection<Ingredient> Ingredients { get; set; }
    public PizzaSize Size { get; set; }
    public DoughType Dough { get; set; }
}