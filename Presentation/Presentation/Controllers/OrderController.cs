using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("/orders")]
public class OrderController(IOrderService orderService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateOrder(OrderRequestDto orderRequestDto)
    {
        var order = await orderService.CreateOrder(orderRequestDto);
        return Ok(order);
    }
}