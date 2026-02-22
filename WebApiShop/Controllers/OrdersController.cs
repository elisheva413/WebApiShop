using Microsoft.AspNetCore.Mvc;
using Entities;
using System.Collections.Generic;
using Repositeries;
using Service;
using DTOs;

namespace WebApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> Get(int id)
        {
            OrderDTO order = await _orderService.GetOrderById(id);
            return order != null ? Ok(order) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> AddOrder([FromBody] Order order)
        {
            OrderDTO orderDto = await _orderService.AddOrder(order);
            if (orderDto == null)
                return BadRequest();
            return CreatedAtAction(nameof(Get), new { id = orderDto.OrderId }, orderDto);
        }

    }
}