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
    public class CategoryRepositoryUnitTests
    {
        [Fact]
        public async Task GetCategory_ReturnsListOfCategories()
        {
            // Arrange
            var categories = new List<Category>
        {
            new Category { CategoryName = "Electronics" },
            new Category { CategoryName = "Books" }
        };

            var mockSet = new Mock<DbSet<Category>>();
            mockSet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.AsQueryable().Provider);
            mockSet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.AsQueryable().Expression);
            mockSet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.AsQueryable().ElementType);
            mockSet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categories.GetEnumerator());

            var mockContext = new Mock<Store_215962135Context>();
            mockContext.Setup(c => c.Categories).Returns(mockSet.Object);

            var repository = new CategoryRepository(mockContext.Object);

            // Act
            var result = await repository.GetCategory();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }
    }
}
