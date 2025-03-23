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
        var createdPizzas = new List<OrderedPizza>();
        var additionalIngredientsList = new List<ChosenIngredient>();
        decimal totalPrice = 0;

        foreach (var orderedPizza in orderedPizzas)
        {
            var pizzaId = orderedPizza.PizzaId;
            var pizza = await pizzaRepository.GetPizzaById(pizzaId);

            var ingredientIds = orderedPizza.AdditionalIngredients.Select(x => x.Id).ToList();
            var additionalIngredients = await pizzaRepository.GetAllIngredients(ingredientIds);

            foreach (var additionalIngredientDto in orderedPizza.AdditionalIngredients)
            {
                var chosenIngredient = new ChosenIngredient
                {
                    IngredientId = additionalIngredientDto.Id,
                    Quantity = additionalIngredientDto.Quantity,
                    TotalPrice = additionalIngredientDto.Quantity * additionalIngredientDto.Price
                };

                var newChosenIngredient = await pizzaRepository.CreateChosenIngredient(chosenIngredient);
                additionalIngredientsList.Add(newChosenIngredient);
            }

            var pizzaWithDetails = orderedPizza.ToOrderedPizza();
            pizzaWithDetails.Pizza = pizza;

            orderedPizzasWithDetails.Add(pizzaWithDetails);

            totalPrice += pizza.Price + additionalIngredientsList.Sum(x => x.TotalPrice);

            var createdPizza = await orderedPizzaRepository.CreateOrderedPizza(pizzaWithDetails);
            createdPizzas.Add(createdPizza);
        }
        var order = await orderRepository.CreateOrder(
            orderRequestDto.ToOrder(createdPizzas.Select(x => x.Id).ToList(),totalPrice));

        var orderResponse = new OrderResponseDto
        {
            Address = orderRequestDto.Address,
            TotalPrice = order.TotalPrice,
            OrderedPizzas = createdPizzas
                .Select(pizzaWithDetails => pizzaWithDetails.ToOrderedPizzaResponseDto(
                    additionalIngredientsList
                        .Where(x => pizzaWithDetails.AdditionalIngredientsIds
                            .Contains(x.IngredientId)) 
                        .Select(x => x.ToAdditionalIngredientDto())
                        .ToList(),
                    pizzaWithDetails.Pizza))
                .ToList()
        };

        return orderResponse;
    }

    public async Task<OrderResponseDto> GetOrderById(int orderId)
    {
        var orderedPizzas = await orderedPizzaRepository.GetAllOrderedPizzasByOrderId(orderId);

        var additionalIngredientsList = new List<ChosenIngredient>();

        foreach (var ingredientId in orderedPizzas.SelectMany(x => x.AdditionalIngredientsIds))
        {
            var ingredients = await pizzaRepository.GetAllChosenIngredientsByAdditionalIngredientId(ingredientId);
            additionalIngredientsList.AddRange(ingredients);
        }

        var pizza = await pizzaRepository.GetPizzaById(orderedPizzas.Select(x => x.PizzaId)
            .FirstOrDefault()); ///?!!!!!!!!!!!!!!!!!!!!!

        var order = await orderRepository.GetOrderById(orderId);
        return order.ToOrderResponseDto(orderedPizzas,
            additionalIngredientsList.Select(x => x.ToAdditionalIngredientDto()).ToList(), pizza);
    }
}