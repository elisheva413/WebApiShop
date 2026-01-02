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
    public class ProductRepositoryUnitTests
    {
        private Store_215962135Context GetContext()
        {
            var options = new DbContextOptionsBuilder<Store_215962135Context>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new Store_215962135Context(options);
        }

        [Fact]
        public async Task GetProducts_ReturnsEmptyList_WhenNoProducts()
        {
            // Arrange
            var context = GetContext();
            var repository = new ProductRepository(context);

            // Act
            var result = await repository.GetProducts();

            // Assert
            Assert.Empty(result);
        }
    }
}
