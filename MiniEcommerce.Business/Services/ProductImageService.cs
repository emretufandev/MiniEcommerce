using MiniEcommerce.Business.Abstract;
using MiniEcommerce.Business.Models;
using MiniEcommerce.DataAccess.Abstract;
using MiniEcommerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniEcommerce.Business.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IProductImageRepository _productImageRepository;
        public ProductImageService(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }
        public IResult InsertImages(List<ProductImage> productImages)
        {
            _productImageRepository.BulkInsert(productImages);
            return new SuccessResult();
        }

        public bool DeleteImages(List<ProductImage> productImages)
        {
            foreach (var item in productImages)
            {
                _productImageRepository.Delete(item);
            }
            return true;
        }

        public List<ProductImage> GetImagesByProductId(int productId)
        {
            var images = _productImageRepository.GetList(x => x.ProductId == productId);

            return images.ToList();
        }
    }
}
