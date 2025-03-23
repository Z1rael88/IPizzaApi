using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Controller]
[Route("pizzas/")]
public class PizzaController(IPizzaService pizzaService) : ControllerBase
{
    [HttpGet("{pizzaId}")]
    public async Task<IActionResult> GetPizzaById(int pizzaId)
    {
        var pizza = await pizzaService.GetPizzaById(pizzaId);
        return Ok(pizza);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllPizzas()
    {
        var pizza = await pizzaService.GetAllPizzas();
        return Ok(pizza);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePizza([FromBody] PizzaRequestDto pizzaRequestDto)
    {
        var pizza = await pizzaService.CreatePizza(pizzaRequestDto);
        return Ok(pizza);
    }
}