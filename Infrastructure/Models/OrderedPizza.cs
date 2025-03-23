namespace Infrastructure.Models;

public class OrderedPizza : BaseModel
{
    public int PizzaId { get; set; }
    public Pizza Pizza { get; set; }
    public  decimal Sum { get; set; }
    public ICollection<int>? AdditionalIngredientsIds { get; set; }
}