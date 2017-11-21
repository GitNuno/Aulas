using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;
using System.Linq;
using SportsStore.Models;
using SportsStore.Controllers;
/*
Criar SportsStore.Tests:
.Rck sln > add new project > UnitTest Project > OK

Referenciar SportsStore em SportsStore.Tests
.Rck SportsStore.Tests > add references > "checkBox" SportsStore  

Correr Teste:
.Test > Win > TestExplorer
.Em TestExplorer > Run All

Notas:
.Instalar Package Moq (ir ao site e correr instalador) - se necessario
.Instalar Microsoft.Composition (Tools > NugetPackageManager ...)

*/
namespace SportsStore.Tests
{
    // mudei nome para: ProductsControllerTests
    public class ProductsControllerTests
    {
        // Fact é o meu Teste; mudei nome para canPaginate()
        [Fact]
        public void canPaginate()
        {
            //Arrange
            Mock<IProductRepository> mockProdRep = new Mock<IProductRepository>();

            // Setup: configuração
            // referencio tabela de produtos; se fosse outra ...
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

            ProductsController controller = new ProductsController(repository);

            //Act
            // estou a testar n. de paginas = 3
            controller.PageSize = 3;
            // List(3) refere pag. 3
            // Model é quem tem os produtos
            ViewResult viewResult = controller.List(3);
            // nota: (IEnumerable<Product>) opode ser substituido por var
            // *** DUVIDA: o tipo de dados mudou em List.cshtml(): ProductsListViewModel e dá ERRO
            IEnumerable<Product> productsList = (IEnumerable<Product>)viewResult.Model;

            //Assert
            Product[] products = productsList.ToArray(); // nota: ToArray => using System.Linq

            Assert.Equal(products.Count(), 2);
            Assert.True(products[0].Name == "P7"); // nome tem de ser igual a P7
            Assert.True(products[1].Name == "P8");
        }
    }
}
