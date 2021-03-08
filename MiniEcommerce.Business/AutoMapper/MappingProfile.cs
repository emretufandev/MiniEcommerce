using AutoMapper;
using MiniEcommerce.Business.Models;
using MiniEcommerce.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniEcommerce.Business.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Product Mapper

            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductModel, Product>();
            CreateMap<Product, ProductModel>();

            CreateMap<Product, ProductListViewModel>()
                .ForMember(dest => dest.DefaultImageUrl, opt => opt.MapFrom(src => src.ProductImages[0]));

            CreateMap<List<Product>, List<ProductListViewModel>>();

            #endregion
        }
    }
}
