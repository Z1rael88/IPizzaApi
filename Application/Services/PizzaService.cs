using Application.Dtos;
using Application.Interfaces;
using Application.Mappers;
using Infrastructure.Interfaces;

namespace Application.Services;

public class PizzaService(IPizzaRepository pizzaRepository) : IPizzaService
{
    public async Task<PizzaResponseDto> GetPizzaById(int pizzaId)
    {
      var pizza = await pizzaRepository.GetPizzaById(pizzaId);
      return pizza.ToPizzaResponse();
    }

    public async Task<ICollection<PizzaResponseDto>> GetAllPizzas()
    {
        var pizzas = await pizzaRepository.GetAllPizzas();

        return pizzas.Select(pizza => pizza.ToPizzaResponse()).ToList();  
    }

    public async Task<PizzaResponseDto> CreatePizza(PizzaRequestDto pizzaRequestDto)
    {
        var ingredients = await pizzaRepository.GetAllIngredients(pizzaRequestDto.IngredientsIds);
        var pizza = pizzaRequestDto.ToPizza(ingredients);
        var newPizza = await pizzaRepository.CreatePizza(pizza);
        return newPizza.ToPizzaResponse();
    }
}