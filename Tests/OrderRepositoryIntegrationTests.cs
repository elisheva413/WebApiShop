//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Moq;
//using Xunit;
//using Microsoft.EntityFrameworkCore;
//using Repositeries;
//using Entities;


//namespace Tests
//{
//    public class OrderRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
//    {
//        private readonly Store_215962135Context _dbContext;
//        private readonly OrderRepository _OrderRepository;

//        public OrderRepositoryIntegrationTests(DatabaseFixture databaseFixture)
//        {
//            _dbContext = databaseFixture.Context;
//            _OrderRepository = new OrderRepository(_dbContext);
//        }
//        public async Task AddOrder_HappyPath()
//        {
//            // Arrange
//            var category = new Category
//            {
//                CategoryName = "Electronics"
//            };

//            var user = new User
//            {
//                UserName= "testuser@example.com",
//                FirstName = "Test",
//                LastName = "User",
//                Password = "password123"
//            };

//            var product1 = new Product
//            {
//                ProductsName = "Product 1",
//                CategoryId = 1,
//                ProductsDescreption = "Description 1",
//                Price = 10.0,
//                ImgUrl = "a.png"
//            };

//            var product2 = new Product
//            {
//                ProductsName = "Product 2",
//                CategoryId = 1,
//                ProductsDescreption = "Description 2",
//                Price = 15.0,
//                ImgUrl = "a.png"
//            };

//            await _dbContext.Categories.AddAsync(category);
//            await _dbContext.Users.AddAsync(user);
//            await _dbContext.Products.AddAsync(product1);
//            await _dbContext.Products.AddAsync(product2);
//            await _dbContext.SaveChangesAsync();

//            var order = new Order
//            {
//                OrderDate = DateOnly.FromDateTime(DateTime.UtcNow),
//                OrderSum = 35, // 2 * 10 + 1 * 15
//                UserId = 1,
//                OrdersItems = new List<OrdersItem>
//                {
//                    new OrdersItem { ProductsId =1, Quantity = 2 },
//                    new OrdersItem { ProductsId = 2, Quantity = 1 }
//                }
//            };

//            // Act
//            var result = await OrderRepository.AddOrder(order);

//            // Assert
//            Assert.NotNull(result);
//            Assert.Equal(order.OrderSum, result.OrderSum);
//            Assert.Equal(2, result.OrderItems.Count); // Verify total items
//        }

//        [Fact]
//        public async Task GetById_ReturnsOrder()
//        {
//            // Arrange
//            var category = new Category
//            {
//                CategoryName = "Books"
//            };

//            var user = new User
//            {
//                UserName = "testuser2@example.com",
//                FirstName = "Test2",
//                LastName = "User2",
//                Password = "password456"
//            };

//            var product = new Product
//            {
//                ProductsName = "Product 3",
//                CategoryId = 1,
//                Price = 20.0,
//                ImgUrl = "a.png"
//            };

//            await _dbContext.Categories.AddAsync(category);
//            await _dbContext.Users.AddAsync(user);
//            await _dbContext.Products.AddAsync(product);
//            await _dbContext.SaveChangesAsync();

//            var order = new Order
//            {
//                OrderDate = DateOnly.FromDateTime(DateTime.UtcNow),
//                OrderSum = 20, // 1 * 20
//                UserId = 1,
//                OrdersItems = new List<OrdersItem>
//                {
//                    new OrdersItem { ProductsId = 1, Quantity = 1 }
//                }
//            };

//            await _OrderRepository.AddOrder(order);

//            // Act
//            var result = await _OrderRepository.GetOrderById(1);

//            // Assert
//            Assert.NotNull(result);
//            Assert.Equal(order.OrderSum, result.OrderSum);
//            Assert.Single(result.OrdersItems);
//        }

//        [Fact]
//        public async Task GetOrderById_ReturnsNull_UnhappyPath()
//        {
//            // Arrange
//            // No order with this ID exists

//            // Act
//            var result = await _OrderRepository.GetOrderById(999); // Assuming 999 does not exist

//            // Assert
//            Assert.Null(result);
//        }
//    }
//}
   