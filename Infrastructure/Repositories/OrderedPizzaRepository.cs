using Infrastructure.Interfaces;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OrderedPizzaRepository(IAppDbContext dbContext) : IOrderedPizzaRepository
{
    public async Task<OrderedPizza> CreateOrderedPizza(OrderedPizza orderedPizza)
    {
        var createdOrderedPizza = await dbContext.OrderedPizzas.AddAsync(orderedPizza);
        await dbContext.SaveChangesAsync();
        return createdOrderedPizza.Entity;
    }

    public async Task<OrderedPizza> GetOrderedPizzaById(int orderedPizzaId)
    {
        var orderedPizza = await dbContext.OrderedPizzas.Where(x => x.Id == orderedPizzaId).SingleOrDefaultAsync();
        if (orderedPizza == null)
        {
            throw new ArgumentException($"Ordered Pizza with Id: {orderedPizzaId} not found");
        }

        return orderedPizza;
    }

    public async Task<ICollection<OrderedPizza>> GetAllOrderedPizzasByOrderId(int orderId)
    {
        var order = await dbContext.Orders.Where(x => x.Id == orderId).SingleOrDefaultAsync();
        var ids = order.OrderedPizzasIds;
        var orderedPizzas = new List<OrderedPizza>();
        foreach (var id in ids)
        {
            var orderedPizza = await dbContext.OrderedPizzas.Where(x => x.Id == id).SingleOrDefaultAsync();
            orderedPizzas.Add(orderedPizza);
        }

        return orderedPizzas;
    }
}