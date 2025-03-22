using Application.Dtos;
using Infrastructure.Models;

namespace Application.Mappers;

public static class PizzaMapper
{
    public static IngredientDto ToIngredientDto(this Ingredient ingredient)
    {
        IngredientDto ingredientDto = new IngredientDto
        {
            IngredientType = ingredient.IngredientType,
            Name = ingredient.Name,
            Price = ingredient.Price
        };
        return ingredientDto;
    }

    public static PizzaResponseDto ToPizzaResponse(this Pizza pizza)
    {
        var ingredientDtos = pizza.Ingredients.Select(ingredient => ingredient.ToIngredientDto()).ToList();

        PizzaResponseDto pizzaResponseDto = new PizzaResponseDto
        {
            Dough = pizza.Dough,
            Id = pizza.Id,
            PhotoUrl = pizza.PhotoUrl,
            Ingredients = ingredientDtos,
            Name = pizza.Name,
            Price = pizza.Price,
            Size = pizza.Size
        };
        return pizzaResponseDto;
    }

    public static Pizza ToPizza(this PizzaRequestDto pizzaRequestDto, ICollection<Ingredient> ingredients)
    {
        Pizza pizza = new Pizza
        {
            Dough = pizzaRequestDto.Dough,
            PhotoUrl = pizzaRequestDto.PhotoUrl,
            Ingredients = ingredients,
            Name = pizzaRequestDto.Name,
            Price = pizzaRequestDto.Price,
            Size = pizzaRequestDto.Size
        };
        return pizza;
    }
}