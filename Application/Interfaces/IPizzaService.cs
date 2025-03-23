using Application.Dtos;

namespace Application.Interfaces;

public interface IPizzaService
{
    Task<PizzaResponseDto> GetPizzaById(int pizzaId);
    Task<ICollection<PizzaResponseDto>> GetAllPizzas();
    Task<PizzaResponseDto> CreatePizza(PizzaRequestDto pizzaRequestDto);
    Task<ICollection<IngredientDto>> GetAllIngredients();

}