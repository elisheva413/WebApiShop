using AutoMapper;
using DTOs;
using Entities;
using Repositories;

namespace Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        

        public async Task<OrderDTO> GetOrderById(int id)
        {
            Order order = await _orderRepository.GetOrderById(id);
            OrderDTO orderDto =_mapper.Map<Order,OrderDTO>(order);
            return orderDto;

        }

        public async Task<OrderDTO> AddOrder(Order order)
        {
            Order newOrder = await _orderRepository.AddOrder(order);
            OrderDTO orderDto = _mapper.Map<Order, OrderDTO>(order);
            return orderDto;
            ;
        }

    }
}