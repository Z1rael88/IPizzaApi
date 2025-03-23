using Application.Dtos;
using Infrastructure.Models;

namespace Application.Mappers;

public static class OrderMapper
{
    public static OrderResponseDto ToOrderResponseDto(this Order order,ICollection<OrderedPizza> orderedPizzas, ICollection<AdditionalIngredientDto> additionalIngredientDtos,Pizza pizza)
    {
        
        return new OrderResponseDto
        {
            Address = order.Address,
            TotalPrice = order.TotalPrice,
            OrderedPizzas = orderedPizzas.Select(x=>x.ToOrderedPizzaResponseDto(additionalIngredientDtos,pizza)).ToList(),
        };
    }

    public static Order ToOrder(this OrderRequestDto orderRequestDto,ICollection<int> orderedPizzasIds)
    {
        return new Order
        {
            Address = orderRequestDto.Address,
            OrderedPizzasIds = orderedPizzasIds
        };
    }

    public static OrderedPizzaResponseDto ToOrderedPizzaResponseDto(this OrderedPizza orderedPizza,ICollection<AdditionalIngredientDto> additionalIngredientDto,Pizza pizza)
    {
        return new OrderedPizzaResponseDto
        {
            PizzaId = orderedPizza.PizzaId,
            AdditionalIngredients = additionalIngredientDto,
            Sum = orderedPizza.Sum,
            PizzaName = pizza.Name,
            DoughType = pizza.Dough,
            Size = pizza.Size,
            PhotoUrl = pizza.PhotoUrl
        };
    }

    public static OrderedPizza ToOrderedPizza(this OrderedPizzaDto orderedPizzaDto)
    {
        return new OrderedPizza
        {
            PizzaId = orderedPizzaDto.PizzaId,
            AdditionalIngredientsIds = orderedPizzaDto.AdditionalIngredients.Select(x=>x.Id).ToList(),
            Sum = orderedPizzaDto.Sum
        };
    }
}