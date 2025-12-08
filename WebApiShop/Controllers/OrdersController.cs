using Microsoft.AspNetCore.Mvc;
using Entities;
using System.Collections.Generic;
using Repositeries;
using Service;
//using User=Repositeries.User;



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
        public async Task<ActionResult<Order>> Get(int id)
        {
            Order order = await _orderService.GetOrderById(id);
            return order != null ? Ok(order) : NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Order>> AddOrder([FromBody] Order newOrder)
        {
            Order order = await _orderService.AddOrder(newOrder);
            if (order == null) { return BadRequest(); }
            return CreatedAtAction(nameof(Get), new { id = order.OrderId }, order);
        }

    }
}