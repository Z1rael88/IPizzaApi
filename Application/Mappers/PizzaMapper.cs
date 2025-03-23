using Application.Dtos;
using Infrastructure.Models;

namespace Application.Mappers;

public static class PizzaMapper
{
    public static AdditionalIngredientDto ToAdditionalIngredientDto(this ChosenIngredient chosenIngredient)
    {
        AdditionalIngredientDto res = new AdditionalIngredientDto
        {
            Quantity = chosenIngredient.Quantity,
            Id = chosenIngredient.Id,
            Price = chosenIngredient.TotalPrice
        };
        return res;
    }
    public static IngredientDto ToIngredientDto(this Ingredient ingredient)
    {
        IngredientDto ingredientDto = new IngredientDto
        {
            IngredientType = ingredient.IngredientType,
            Name = ingredient.Name,
            Price = ingredient.Price,
            Id = ingredient.Id
        };
        return ingredientDto;
    }

    public static Ingredient ToIngredient(this IngredientDto ingredientDto)
    {
        Ingredient ingredient = new Ingredient
        {
            Name = ingredientDto.Name,
            Price = ingredientDto.Price,
            IngredientType = ingredientDto.IngredientType
        };
        return ingredient;
    }

    public static PizzaResponseDto ToPizzaResponse(this Pizza pizza, ICollection<IngredientDto> ingredients)
    {
        PizzaResponseDto pizzaResponseDto = new PizzaResponseDto
        {
            Dough = pizza.Dough,
            Id = pizza.Id,
            PhotoUrl = pizza.PhotoUrl,
            Ingredients = ingredients,
            Name = pizza.Name,
            Price = pizza.Price,
            Size = pizza.Size
        };
        return pizzaResponseDto;
    }

    public static Pizza ToPizza(this PizzaRequestDto pizzaRequestDto, ICollection<int> ingredientsIds)
    {
        Pizza pizza = new Pizza
        {
            Dough = pizzaRequestDto.Dough,
            PhotoUrl = pizzaRequestDto.PhotoUrl,
            Ingredientsids = ingredientsIds,
            Name = pizzaRequestDto.Name,
            Price = pizzaRequestDto.Price,
            Size = pizzaRequestDto.Size
        };
        return pizza;
    }
}