using MiniEcommerce.Business.Models;
using MiniEcommerce.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniEcommerce.Business.Abstract
{
    public interface IProductImageService
    {
        IResult InsertImages(List<ProductImage> productImages);
        List<ProductImage> GetImagesByProductId(int productId);
        bool DeleteImages(List<ProductImage> productImages);
    }
}
