using Application.Dtos;

namespace Application.Interfaces;

public interface IOrderService
{
    Task<OrderResponseDto> CreateOrder(OrderRequestDto order);
    Task<OrderResponseDto> GetOrderById(int orderId);
}