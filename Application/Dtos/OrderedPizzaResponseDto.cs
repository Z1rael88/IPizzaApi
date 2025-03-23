using Infrastructure.Enums;

namespace Application.Dtos;

public class OrderedPizzaResponseDto
{
    public ICollection<AdditionalIngredientDto>? AdditionalIngredients { get; set; }
    public decimal Sum { get; set; }
    public string PizzaName { get; set; }
    public int PizzaId { get; set; }
    public DoughType DoughType { get; set; }
    public PizzaSize Size { get; set; }
    public string PhotoUrl { get; set; }
}