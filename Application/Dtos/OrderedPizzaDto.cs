namespace Application.Dtos;

public class OrderedPizzaDto
{
    public int PizzaId { get; set; }
    public ICollection<int>? AdditionalIngredientsIds { get; set; }
}