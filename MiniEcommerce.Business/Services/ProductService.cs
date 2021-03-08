using MiniEcommerce.Business.Abstract;
using MiniEcommerce.Business.Models;
using MiniEcommerce.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using MiniEcommerce.Entity;
using System.Linq;
using FluentValidation;
using MiniEcommerce.Business.ValidationRules;

namespace MiniEcommerce.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<ProductModel> _productValidator;

        public ProductService(IProductRepository productRepository, IMapper mapper, IValidator<ProductModel> productValidator)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productValidator = productValidator;
        }
        public IDataResult<ProductModel> Create(ProductModel productModel)
        {
            // FluentValidation for API
            // TODO Move to Cross Cutting Concern with Aspect Oriented Programming
            var validationResult = _productValidator.Validate(productModel);

            //TODO Refactoring extract method this statement 
            if (!validationResult.IsValid)
            {
                StringBuilder stringBuilder = new StringBuilder();

                foreach (var error in validationResult.Errors)
                {
                    stringBuilder.Append(error.ErrorMessage + ", ");
                }
                return new ErrorDataResult<ProductModel>(productModel, stringBuilder.ToString().Replace(",", ""));
            }


            if (_productRepository.ExistBarcode(productModel.Barcode))
                return new ErrorDataResult<ProductModel>(productModel, $"{productModel.Barcode} barkod sistemde zaten kayıtlı.");

            var entity = _mapper.Map<Product>(productModel);

            var result = _productRepository.Insert(entity);

            return new SuccessDataResult<ProductModel>(_mapper.Map<ProductModel>(result), "Ürün başarıyla eklendi.");
        }

        public IResult Delete(int id)
        {
            var product = _productRepository.Get(x => x.Id == id);

            if (product == null)
            {
                return new ErrorResult
                {
                    Message = $"{id}'li ürün bulunamadı."
                };
            }

            _productRepository.Delete(product);

            return new SuccessResult("Ürün başarıyla silindi.");
        }

        public IDataResult<ProductModel> Get(int id)
        {
            var entity = _productRepository.Get(x => x.Id == id);

            if (entity == null)
                return new ErrorDataResult<ProductModel>($"{id}'li ürün bulunamadı.");


            return new SuccessDataResult<ProductModel>(_mapper.Map<ProductModel>(entity));
        }

        public IDataResult<List<ProductListViewModel>> GetList()
        {
            var entities = _productRepository.GetListIncludeImages();

            var result = entities.Select(x => new ProductListViewModel 
            { 
                Id = x.Id,
                Barcode = x.Barcode,
                DefaultImageUrl = x.ProductImages.Any() ? x.ProductImages[0].Url : "",
                Description = x.Description,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock
            }).ToList();

            return new SuccessDataResult<List<ProductListViewModel>>(result);
        }

        public IDataResult<ProductViewModel> GetViewModel(int id)
        {
            var entity = _productRepository.GetIncludeImages(id);

            if (entity == null)
                return new ErrorDataResult<ProductViewModel>($"{id}'li ürün bulunamadı.");

            var result = new ProductViewModel
            {
                Id = entity.Id,
                Barcode = entity.Barcode,
                Description = entity.Description,
                Name = entity.Name,
                Price = entity.Price,
                Stock = entity.Stock,
                ProductImages = entity.ProductImages.Select(x => new ProductImageViewModel 
                { 
                    Url = x.Url
                }).ToList()
            };

            return new SuccessDataResult<ProductViewModel>(result);
        }

        public IDataResult<ProductModel> Update(ProductModel productModel)
        {
            var entity = _productRepository.Get(x => x.Id == productModel.Id);

            if (entity == null)
                return new ErrorDataResult<ProductModel>($"{productModel.Id}'li ürün bulunamadı.");

            if (_productRepository.ExistBarcode(productModel.Barcode, productModel.Id))
                return new ErrorDataResult<ProductModel>(productModel, $"{productModel.Barcode} barkod sistemde zaten kayıtlı.");

            entity.Barcode = productModel.Barcode;
            entity.Name = productModel.Name;
            entity.Price = productModel.Price;
            entity.Description = productModel.Description;
            entity.Stock = productModel.Stock;

            var result = _productRepository.Update(entity);

            return new SuccessDataResult<ProductModel>(_mapper.Map<ProductModel>(result), "Ürün güncellendi.");
        }
    }
}
