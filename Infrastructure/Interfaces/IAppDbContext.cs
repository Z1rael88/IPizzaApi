using Infrastructure.Data.Configurations;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Interfaces;

public interface IAppDbContext
{
    DbSet<Pizza> Pizzas { get; set; }
    DbSet<Order> Orders { get; set; }
    DbSet<OrderedPizza> OrderedPizzas { get; set; }
    DbSet<Ingredient> Ingredients { get; set; }
    DbSet<OrderedPizzaIngredients> OrderedPizzaIngredients { get; set; }
    Task<int> SaveChangesAsync();

}