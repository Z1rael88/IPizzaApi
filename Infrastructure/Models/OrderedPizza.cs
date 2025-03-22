namespace Infrastructure.Models;

public class OrderedPizza : BaseModel
{
    public int PizzaId { get; set; }
    public Pizza Pizza { get; set; }
    public int OrderId { get; set; }
    public ICollection<Ingredient>? AdditionalIngredients { get; set; }
    public decimal TotalPrice { get; set; }
}