using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniEcommerce.Business.Abstract;
using MiniEcommerce.Business.AutoMapper;
using MiniEcommerce.Business.Services;
using MiniEcommerce.DataAccess.Abstract;
using MiniEcommerce.DataAccess.EntityFramework;
using MiniEcommerce.DataAccess.EntityFramework.Repositories;
using MiniEcommerce.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using FluentValidation;
using MiniEcommerce.Business.Models;
using MiniEcommerce.Business.ValidationRules;

namespace MiniEcommerce.Business.DependencyResolvers
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EcommerceContext>(options =>
            {
                options.UseSqlServer(
                    configuration["ConnectionStrings:Sql"].ToString(),
                    o => o.MigrationsAssembly("MiniEcommerce.DataAccess")
                    );
            });

            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(
                    configuration["ConnectionStrings:Sql"].ToString(),
                    o => o.MigrationsAssembly("MiniEcommerce.DataAccess")
                    );
            });

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductImageService, ProductImageService>();
            services.AddScoped<IProductRepository, EfProductRepository>();
            services.AddScoped<IProductImageRepository, EfProductImageRepository>();

            //FluentValidation
            services.AddSingleton<IValidator<ProductModel>, ProductValidator>();

            //Automapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            //Identity
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // password
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;

                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/admin/login";
                options.LogoutPath = "/admin/logout";
                options.AccessDeniedPath = "/admin/access-denied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".MiniEcommerce.Security.Cookie"
                };
            });

            return services;
        }
    }
}
