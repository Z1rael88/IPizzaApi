namespace Application.Dtos;

public class OrderedPizzaDto
{
    public int PizzaId { get; set; }
    public decimal Sum { get; set; }
    public ICollection<AdditionalIngredientDto>? AdditionalIngredients { get; set; }
}