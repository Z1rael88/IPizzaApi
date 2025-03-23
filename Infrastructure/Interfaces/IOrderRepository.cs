using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IOrderRepository
{
    Task<Order> CreateOrder(Order order);
    Task<Order> GetOrderById(int orderId);
}