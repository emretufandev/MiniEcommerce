using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniEcommerce.Business.Abstract;
using MiniEcommerce.Business.Models;
using MiniEcommerce.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MiniEcommerce.UI.Controllers
{
    [Authorize]
    public class ProductAdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductImageService _productImageService;
        public ProductAdminController(IProductService productService, IProductImageService productImageService)
        {
            _productService = productService;
            _productImageService = productImageService;
        }
        public IActionResult Index()
        {
            var result = _productService.GetList();
            return View(result);
        }

        public IActionResult Edit(int id)
        {
            var result = _productService.Get(id);

            if (result.Success)
            {
                var images = _productImageService.GetImagesByProductId(id);
                ViewBag.Images = images;
                return View(result.Data);
            }

            return View("ErrorPage", result);
        }

        [HttpPost]
        public IActionResult Edit(ProductModel model, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                var updatedResult = _productService.Update(model);

                if (updatedResult.Success)
                {
                    if (files != null && files.Any())
                    {
                        List<ProductImage> images = new List<ProductImage>();
                        for (int i = 0; i < files.Count; i++)
                        {
                            var extention = Path.GetExtension(files[i].FileName);
                            var name = string.Format($"{model.Name}_{i}{extention}");
                            images.Add(new ProductImage
                            {
                                ProductId = model.Id,
                                Url = $"~/images/{name}"
                            });
                            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", name);

                            using var stream = new FileStream(path, FileMode.Create);
                            files[i].CopyTo(stream);
                        }

                        var existImages = _productImageService.GetImagesByProductId(model.Id);
                        if (existImages.Any())
                        {
                            _productImageService.DeleteImages(existImages);
                            _productImageService.InsertImages(images);
                        }
                    }

                    TempData["Message"] = updatedResult.Message;
                    return RedirectToAction("Index", "ProductAdmin");
                }
                else
                {
                    TempData["Message"] = updatedResult.Message;
                    return View(model);
                }
            }

            return View(model);
        }

        [HttpPost("admin/products/delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _productService.Delete(id);

            if (result.Success)
            {
                TempData["Message"] = result.Message;
            }
            else
            {
                TempData["Error"] = result.Message;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductModel model, List<IFormFile> files)
        {
            if (ModelState.IsValid)
            {
                var result = _productService.Create(model);

                if (result.Success)
                {
                    TempData["Message"] = result.Message;

                    if (files != null && files.Any())
                    {
                        List<ProductImage> images = new List<ProductImage>();
                        for (int i = 0; i < files.Count; i++)
                        {
                            var extention = Path.GetExtension(files[i].FileName);
                            var name = string.Format($"{model.Name}_{i}{extention}");
                            images.Add(new ProductImage
                            {
                                ProductId = result.Data.Id,
                                Url = $"~/images/{name}"
                            });
                            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", name);

                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                files[i].CopyTo(stream);
                            }
                        }

                        _productImageService.InsertImages(images);
                    }

                    return RedirectToAction("Index");
                }

                TempData["Error"] = result.Message;
                return View(model);
            }
            return View(model);
        }
    }
}
