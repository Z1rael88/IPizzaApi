using Application.Dtos;
using Application.Interfaces;
using Application.Mappers;
using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Application.Services;

public class OrderService(
    IOrderRepository orderRepository,
    IPizzaRepository pizzaRepository,
    IOrderedPizzaRepository orderedPizzaRepository) : IOrderService
{
    public async Task<OrderResponseDto> CreateOrder(OrderRequestDto orderRequestDto)
    {
        var orderedPizzas = orderRequestDto.OrderedPizzas;
        var orderedPizzasWithDetails = new List<OrderedPizza>();
        decimal totalPrice = 0;

        foreach (var orderedPizza in orderedPizzas)
        {
            var pizzaId = orderedPizza.PizzaId;
            var pizza = await pizzaRepository.GetPizzaById(pizzaId);
            var additionalIngredients = await pizzaRepository.GetAllIngredients(orderedPizza.AdditionalIngredientsIds);

            var pizzaWithDetails = orderedPizza.ToOrderedPizza();
            pizzaWithDetails.Pizza = pizza;

            orderedPizzasWithDetails.Add(pizzaWithDetails);  

            totalPrice += pizza.Price + additionalIngredients.Sum(ingredient => ingredient.Price);
        }

        var order = await orderRepository.CreateOrder(orderRequestDto.ToOrder());
        order.TotalPrice = totalPrice; 

        foreach (var pizzaWithDetails in orderedPizzasWithDetails)
        {
            pizzaWithDetails.OrderId = order.Id;
            await orderedPizzaRepository.CreateOrderedPizza(pizzaWithDetails);
        }

        return order.ToOrderResponseDto();
    }



    public async Task<OrderResponseDto> GetOrderById(int orderId)
    {
        var order = await orderRepository.GetOrderById(orderId);
        return order.ToOrderResponseDto();
    }
}