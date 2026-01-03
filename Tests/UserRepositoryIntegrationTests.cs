using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositeries;
using Xunit;

namespace Tests
{
    public class UserRipositoryIntegrationTests : IClassFixture<DatabaseFixture>
    {
        private readonly Store_215962135Context _dbContext;
        private readonly UserRipository _userRipository;

        public UserRipositoryIntegrationTests(DatabaseFixture databaseFixture)
        {
            _dbContext = databaseFixture.Context;
            _userRipository = new UserRipository(_dbContext);
        }

        [Fact]
        public async Task GetUsers_ReturnsUsersFromDatabase()
        {
            // Arrange
            var user1 = new User { UserId = 1, UserName = "user1", FirstName = "John", LastName = "Doe" };
            var user2 = new User { UserId = 2, UserName = "user2", FirstName = "Jane", LastName = "Doe" };
            _dbContext.Users.Add(user1);
            _dbContext.Users.Add(user2);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _userRipository.GetUsers();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Contains(result, u => u.UserId == 1);
            Assert.Contains(result, u => u.UserId == 2);
        }

        [Fact]
        public async Task GetUserById_ReturnsUserFromDatabase_WhenUserExists()
        {
            // Arrange
            var user = new User { UserId = 1, UserName = "user1", FirstName = "John", LastName = "Doe" };
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _userRipository.GetUserById(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.UserName, result.UserName);
        }

        [Fact]
        public async Task AddUser_SavesUserToDatabase()
        {
            // Arrange
            var user = new User { UserId = 1, UserName = "user1", FirstName = "John", LastName = "Doe" };

            // Act
            var result = await _userRipository.AddUser(user);

            // Assert
            var savedUser = await _dbContext.Users.FindAsync(user.UserId);
            Assert.NotNull(savedUser);
            Assert.Equal(user.UserName, savedUser.UserName);
        }
    }
}
