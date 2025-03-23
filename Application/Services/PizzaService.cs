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
        var ingredients = await pizzaRepository.GetAllIngredients(pizza.Ingredientsids);
        var ingredientsDto = ingredients.Select(ingredient => ingredient.ToIngredientDto()).ToList();

        return pizza.ToPizzaResponse(ingredientsDto);
    }

    public async Task<ICollection<PizzaResponseDto>> GetAllPizzas()
    {
        var pizzas = await pizzaRepository.GetAllPizzas();
    
        // Return an empty list if there are no pizzas
        if (pizzas.Count < 1)
        {
            return new List<PizzaResponseDto>();
        }

        var pizzaResponseDtos = new List<PizzaResponseDto>();

        foreach (var pizza in pizzas)
        {
            var ingredientIds = pizza.Ingredientsids;
            var ingredients = await pizzaRepository.GetAllIngredients(ingredientIds);
        
            var ingredientsDto = ingredients.Select(ingredient => ingredient.ToIngredientDto()).ToList();

            var pizzaResponse = pizza.ToPizzaResponse(ingredientsDto);
        
            pizzaResponseDtos.Add(pizzaResponse);
        }

        return pizzaResponseDtos;
    }


    public async Task<PizzaResponseDto> CreatePizza(PizzaRequestDto pizzaRequestDto)
    {
        var ingredients = await pizzaRepository.GetAllIngredients(pizzaRequestDto.IngredientsIds);
        var ingredientsDto = ingredients.Select(ingredient => ingredient.ToIngredientDto()).ToList();
        var pizza = pizzaRequestDto.ToPizza(pizzaRequestDto.IngredientsIds);
        var newPizza = await pizzaRepository.CreatePizza(pizza);
        return newPizza.ToPizzaResponse(ingredientsDto);
    }
}