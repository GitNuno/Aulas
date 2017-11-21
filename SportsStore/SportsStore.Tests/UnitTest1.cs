using Microsoft.AspNetCore.Mvc;
using Moq;
using SportsStore.Controllers;
using SportStore.Models;
using System;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace SportsStore.Tests
{
    public class ProductsControllerTests
    {
        [Fact]
        public void canPaginate()
        {
            //Arrange
            Mock<IProductRepository> mockProdRep = new Mock<IProductRepository>();

            mockProdRep.Setup(m => m.Products).Returns(new Product[] {
                new Product { ProductID = 1, Name = "P1"},
                new Product { ProductID = 2, Name = "P2"},
                new Product { ProductID = 3, Name = "P3"},
                new Product { ProductID = 4, Name = "P4"},
                new Product { ProductID = 5, Name = "P5"},
                new Product { ProductID = 6, Name = "P6"},
                new Product { ProductID = 7, Name = "P7"},
                new Product { ProductID = 8, Name = "P8"}
            });

            IProductRepository repository = mockProdRep.Object;

            ProductController controller = new ProductController(repository);
            //Act
            controller.PageSize = 3;
            ViewResult viewResult = controller.List(3);
            IEnumerable<Product> productsList = (IEnumerable<Product>) viewResult.Model;

            //Assert
            Product[] products = productsList.ToArray();

            Assert.Equal(products.Count(), 2);
            Assert.True(products[0].Name == "P7");
            Assert.True(products[1].Name == "P8");
        }
    }
}
