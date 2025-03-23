using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IOrderedPizzaRepository
{
    Task<OrderedPizza> CreateOrderedPizza(OrderedPizza orderedPizza);
    Task<OrderedPizza> GetOrderedPizzaById(int orderedPizzaId);
    Task<ICollection<OrderedPizza>> GetAllOrderedPizzasByOrderId(int orderId);
}