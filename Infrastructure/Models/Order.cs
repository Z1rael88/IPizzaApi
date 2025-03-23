namespace Infrastructure.Models;

public class Order : BaseModel
{
    public ICollection<int> OrderedPizzasIds { get; set; }
    public ICollection<OrderedPizza> OrderedPizzas { get; set; }
    public Address Address { get; set; }
    public decimal TotalPrice { get; set; }
}