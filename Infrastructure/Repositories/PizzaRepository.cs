using Infrastructure.Interfaces;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PizzaRepository(IAppDbContext dbContext) : IPizzaRepository
{
    public async Task<Pizza> GetPizzaById(int pizzaId)
    {
        var pizza = await dbContext.Pizzas.Where(x => x.Id == pizzaId).SingleOrDefaultAsync();
        if (pizza == null)
        {
            throw new ArgumentException($"No pizzas with id: {pizzaId} found");
        }

        return pizza;
    }

    public async Task<ICollection<Pizza>> GetAllPizzas()
    {
        return await dbContext.Pizzas.AsNoTracking().ToListAsync();
    }

    public async Task<Pizza> CreatePizza(Pizza pizza)
    {
       var newPizza = await dbContext.Pizzas.AddAsync(pizza);
       await dbContext.SaveChangesAsync();
       return newPizza.Entity;
    }

    public async Task<ICollection<Ingredient>> GetAllIngredients(ICollection<int> ingredientIds)
    {
        if (!ingredientIds.Any())
        {
            return [];
        }

        var ingredients = await dbContext.Ingredients
            .Where(x => ingredientIds.Contains(x.Id))
            .ToListAsync();

        var orderedIngredients = ingredientIds
            .Select(id => ingredients.FirstOrDefault(x => x.Id == id)) 
            .Where(x => x != null)
            .ToList();
        var missingIngredientIds = ingredientIds.Except(ingredients.Select(x => x.Id)).ToList();
        if (missingIngredientIds.Any())
        {
            throw new ArgumentException($"Ingredients with IDs {string.Join(", ", missingIngredientIds)} not found.");
        }

        return orderedIngredients;
    }

    public async Task<ICollection<Ingredient>> GetAllDefaultIngredients()
    {
       return await dbContext.Ingredients.AsNoTracking().ToListAsync();
    }

    public async Task<ChosenIngredient> CreateChosenIngredient(ChosenIngredient chosenIngredient)
    {
        var ingredient = await dbContext.ChosenIngredients.AddAsync(chosenIngredient);
        return ingredient.Entity;
    }

    public async Task<ICollection<ChosenIngredient>> GetAllChosenIngredientsByAdditionalIngredientId(int additionalIngredientId)
    {
        return await dbContext.ChosenIngredients.Where(x => x.IngredientId == additionalIngredientId).ToListAsync();
    }
}