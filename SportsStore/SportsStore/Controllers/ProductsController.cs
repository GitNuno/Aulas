using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportStore.Models.ViewModels;

// CAMINHO DADOS:
//   .[serviços]: IProductRepository recebeu dados de EFProductRepository>() (ver startup.cs)
//   .[EFProductRepository:IProductRepository]: recebeu dados da BD usando ApplicationDbContext (:DbContext)
//   .[ApplicationDbContext:DbContext]: config. BD com os modelos (DbSet<Product> Products { get; set; })
//      .Nota: A BD foi populada usando SeedData.cs (ver startup.cs) que usa ApplicationDbContext 
//   .[view List]: é do tipo IEnumerable<Product> e exibe campos de Product com: foreach (Product p in Model)

namespace SportsStore.Controllers
{
    public class ProductsController : Controller
    {

        private IProductRepository repository;

        public int PageSize = 4;

        // Controlador vai ver se existe um serviço para IProductRepository
        // dependency injection
        public ProductsController(IProductRepository repository) // construtor
        {
            this.repository = repository;
        }
        /*
        public ViewResult List(int page) // orig.
        {
            return View(repository.Products
                .OrderBy(p => p.Price)
                .Skip(PageSize * (page - 1))
                .Take(PageSize)        
                ); // passa produtos para view: @model IEnumerable<Product>
        }
        */
        public ViewResult List(int page = 1)
        {
            return View(
                new ProductsListViewModel // estou a passar dados nos campos de ProductsListViewModel
                {
                    Products = repository.Products
                    .OrderBy(p => p.Price)
                    .Skip(PageSize * (page - 1))
                    .Take(PageSize),
                    // campo de ProductsListViewModel
                    PagingInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = repository.Products.Count()
                    }
                }
            );
        }

    }
}