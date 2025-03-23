using Infrastructure.Models;

namespace Application.Dtos;

public class OrderResponseDto
{
    public Address Address { get; set; }
    public decimal TotalPrice { get; set; }
    public ICollection<OrderedPizzaDto> OrderedPizzas { get; set; }
}