using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using SportStore.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        public int PageSize = 4;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

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