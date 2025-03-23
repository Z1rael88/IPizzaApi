using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IPizzaRepository
{
    Task<Pizza> GetPizzaById(int pizzaId);
    Task<ICollection<Pizza>> GetAllPizzas();
    Task<Pizza> CreatePizza(Pizza pizza);
    Task<ICollection<Ingredient>> GetAllIngredients(ICollection<int> ingredientIds);
    Task<ICollection<Ingredient>> GetAllDefaultIngredients();
    Task<ChosenIngredient> CreateChosenIngredient(ChosenIngredient chosenIngredient);
    Task<ICollection<ChosenIngredient>> GetAllChosenIngredientsByAdditionalIngredientId(int additionalIngredientId);
}