using MiniEcommerce.Core.DataAccess.Abstract;
using MiniEcommerce.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniEcommerce.DataAccess.Abstract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        bool ExistBarcode(string barcode, int productId = 0);
        IEnumerable<Product> GetListIncludeImages();
        Product GetIncludeImages(int id);
    }
}