using MiniEcommerce.Business.Models;
using MiniEcommerce.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniEcommerce.Business.Abstract
{
    public interface IProductService
    {
        IDataResult<ProductModel> Get(int id);
        IDataResult<ProductViewModel> GetViewModel(int id);
        IDataResult<List<ProductListViewModel>> GetList();
        IDataResult<ProductModel> Create(ProductModel productModel);
        IDataResult<ProductModel> Update(ProductModel productModel);
        IResult Delete(int id);
    }
}
