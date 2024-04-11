using IntexLego.Models;
using IntexLego.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Diagnostics;

namespace IntexLego.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Products()
        {
            return View();
        }

        private I_Repository _repo;
        public HomeController(I_Repository temp)
        {
            _repo = temp;
        }


        public IActionResult ListProducts(string? primaryColor, int pageNum = 1) // name this pageNum, because "page" means something to the .NET environment
        {
            int pageSize = 5;
            var PageInfo = new DefaultListViewModel
            {
                Products = _repo.Products
                .Where(x => x.PrimaryColor == primaryColor || primaryColor == null)
                .OrderBy(x => x.ProductId)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = primaryColor == null ? _repo.Products.Count() : _repo.Products.Where(x => x.PrimaryColor == primaryColor).Count()
                },

                CurrentPrimaryColor = primaryColor
            };

            return View(PageInfo);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        
        //public IActionResult AdminOrders(int? fraud, int pageNum = 1) // we will want to pass in the fradulent bool here so that we can filter.
        //{
        //    int pageSize = 5;
        //    var PageInfo = new DefaultListViewModel
        //    {
        //        Products = _repo.Products
        //        .Where(x => x.PrimaryColor == primaryColor || primaryColor == null)
        //        .OrderBy(x => x.ProductId)
        //        .Skip((pageNum - 1) * pageSize)
        //        .Take(pageSize),

        //        PaginationInfo = new PaginationInfo
        //        {
        //            CurrentPage = pageNum,
        //            ItemsPerPage = pageSize,
        //            TotalItems = primaryColor == null ? _repo.Products.Count() : _repo.Products.Where(x => x.PrimaryColor == primaryColor).Count()
        //        },

        //        CurrentPrimaryColor = primaryColor
        //    };

        //    return View(PageInfo);
        //}
        public IActionResult AdminProducts()
        {
            return View();
        }
    }
}
