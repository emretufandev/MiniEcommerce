using Microsoft.AspNetCore.Mvc;
using MiniEcommerce.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniEcommerce.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Detail(int id)
        {
            var result = _productService.GetViewModel(id);

            if (result.Success)
            {
                return View(result.Data);
            }

            return View("ErrorPage", result);
        }
    }
}
