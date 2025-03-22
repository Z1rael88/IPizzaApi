namespace Infrastructure.Models;

public class OrderedPizzaIngredients : BaseModel
{
    public int OrderedPizzaId { get; set; }
    public OrderedPizza OrderedPizza { get; set; }

    public int IngredientId { get; set; }
    public Ingredient Ingredient { get; set; }
}