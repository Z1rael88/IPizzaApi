using Infrastructure.Models;

namespace Application.Dtos;

public class OrderRequestDto
{
    public Address Address { get; set; }
    public ICollection<OrderedPizzaDto> OrderedPizzas { get; set; }
}