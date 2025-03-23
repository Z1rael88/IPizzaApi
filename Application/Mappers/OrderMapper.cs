using Application.Dtos;
using Infrastructure.Models;

namespace Application.Mappers;

public static class OrderMapper
{
    public static OrderResponseDto ToOrderResponseDto(this Order order)
    {
        return new OrderResponseDto
        {
            Address = order.Address,
            OrderedPizzas = order.OrderedPizzas.Select(x => x.ToOrderedPizzaDto()).ToList(),
            TotalPrice = order.TotalPrice
        };
    }

    public static Order ToOrder(this OrderRequestDto orderRequestDto)
    {
        var orderedPizzas = orderRequestDto.OrderedPizzas
            .Select(x => x.ToOrderedPizza())
            .Distinct() 
            .ToList();

        return new Order
        {
            Address = orderRequestDto.Address,
            OrderedPizzas = orderedPizzas,
            OrderedPizzasIds = orderedPizzas.Select(x => x.Id).Distinct().ToList() 
        };
    }

    public static OrderedPizzaDto ToOrderedPizzaDto(this OrderedPizza orderedPizza)
    {
        return new OrderedPizzaDto
        {
            PizzaId = orderedPizza.PizzaId,
            AdditionalIngredientsIds = orderedPizza.AdditionalIngredientsIds
        };
    }

    public static OrderedPizza ToOrderedPizza(this OrderedPizzaDto orderedPizzaDto)
    {
        return new OrderedPizza
        {
            PizzaId = orderedPizzaDto.PizzaId,
            AdditionalIngredientsIds = orderedPizzaDto.AdditionalIngredientsIds
        };
    }
}