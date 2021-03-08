using Microsoft.EntityFrameworkCore;
using MiniEcommerce.Core.DataAccess.EntityFramework;
using MiniEcommerce.DataAccess.Abstract;
using MiniEcommerce.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniEcommerce.DataAccess.EntityFramework.Repositories
{
    public class EfProductRepository : EfRepositoryBase<Product, EcommerceContext>, IProductRepository
    {
        public EfProductRepository(EcommerceContext context) : base(context)
        {

        }

        public IEnumerable<Product> GetListIncludeImages()
        {
            return _context.Products.Include(x => x.ProductImages).ToList();
        }

        public bool ExistBarcode(string barcode, int productId = 0)
        {
            if(productId > 0)
                return _context.Products.Any(x => x.Barcode == barcode && x.Id != productId);

            return _context.Products.Any(x => x.Barcode == barcode);
        }

        public Product GetIncludeImages(int id)
        {
            return _context.Products.Where(x => x.Id == id).Include(x => x.ProductImages).SingleOrDefault();
        }
    }
}
