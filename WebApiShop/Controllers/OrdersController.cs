using Microsoft.AspNetCore.Mvc;
using Entities;
using System.Collections.Generic;
using Repositories;
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

        [HttpGet]

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> Get(int id)
        {
            OrderDTO order = await _orderService.GetOrderById(id);
            return order != null ? Ok(order) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> AddOrder([FromBody] Order Order)
        {
            OrderDTO order = await _orderService.AddOrder(Order);
            if (order == null) { return BadRequest(); }
            return CreatedAtAction(nameof(Get), new { id = order.OrderId }, order);
        }

    }
}