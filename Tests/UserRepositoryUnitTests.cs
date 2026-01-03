using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Entities;
using Repositeries;


namespace Tests
{
    public class UserRipositoryTests
    {
        private readonly Mock<Store_215962135Context> _mockContext;
        private readonly UserRipository _userRipository;

        public UserRipositoryTests()
        {
            _mockContext = new Mock<Store_215962135Context>();
            _userRipository = new UserRipository(_mockContext.Object);
        }

        [Fact]
        public async Task GetUsers_ReturnsListOfUsers()
        {
            // Arrange
            var users = new List<User>
        {
            new User { UserId = 1, UserName = "user1", FirstName = "John", LastName = "Doe" },
            new User { UserId = 2, UserName = "user2", FirstName = "Jane", LastName = "Doe" }
        };

            var mockSet = new Mock<DbSet<User>>();
            mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.AsQueryable().Provider);
            mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.AsQueryable().Expression);
            mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.AsQueryable().ElementType);
            mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator());

            _mockContext.Setup(c => c.Users).Returns(mockSet.Object);

            // Act
            var result = await _userRipository.GetUsers();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetUserById_ReturnsUser_WhenUserExists()
        {
            // Arrange
            var user = new User { UserId = 1, UserName = "user1", FirstName = "John", LastName = "Doe" };
            _mockContext.Setup(m => m.Users.FindAsync(1)).ReturnsAsync(user);

            // Act
            var result = await _userRipository.GetUserById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.UserName, result.UserName);
        }

        [Fact]
        public async Task AddUser_AddsUserSuccessfully()
        {
            // Arrange
            var user = new User { UserId = 1, UserName = "user1", FirstName = "John", LastName = "Doe" };

            // Act
            var result = await _userRipository.AddUser(user);

            // Assert
            _mockContext.Verify(m => m.Users.AddAsync(user, default), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(default), Times.Once);
            Assert.Equal(user.UserName, result.UserName);
        }
    }
}
