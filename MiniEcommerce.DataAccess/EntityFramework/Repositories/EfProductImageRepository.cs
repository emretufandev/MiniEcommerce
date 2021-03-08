using MiniEcommerce.Core.DataAccess.EntityFramework;
using MiniEcommerce.DataAccess.Abstract;
using MiniEcommerce.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniEcommerce.DataAccess.EntityFramework.Repositories
{
    public class EfProductImageRepository : EfRepositoryBase<ProductImage, EcommerceContext>, IProductImageRepository
    {
        public EfProductImageRepository(EcommerceContext context) : base(context)
        {

        }
    }
}
