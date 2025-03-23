namespace Infrastructure.Models;

public class ChosenIngredient
{
    public int Id { get; set; }
    public int IngredientId { get; set; }
    public Ingredient Ingredient { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}