using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniEcommerce.Business.Abstract;
using MiniEcommerce.Business.Models;
using MiniEcommerce.UI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MiniEcommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var result = _productService.GetList();
            return View(result.Data.ToList());
        }
    }
}
