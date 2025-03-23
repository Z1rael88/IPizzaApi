using Infrastructure.Interfaces;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OrderRepository(IAppDbContext dbContext): IOrderRepository
{
    public async Task<Order> CreateOrder(Order order)
    {
        var createdOrder = await dbContext.Orders.AddAsync(order);
        await dbContext.SaveChangesAsync();
        return createdOrder.Entity;
    }

    public async Task<Order> GetOrderById(int orderId)
    {
        var order = await dbContext.Orders.Where(x => x.Id == orderId).SingleOrDefaultAsync();
        if (order == null)
        {
            throw new ArgumentException($"Order with Id: {orderId} not found");
        }

        return order;
    }
}