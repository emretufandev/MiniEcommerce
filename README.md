
# MiniEcommerce

### Migrations
- add-migration EcommerceContextTables -context EcommerceContext
- add-migration ApplicationContextTables -context ApplicationContext
- update-database

### Notlar
- Business katmanındaki modellere DataAnnotations tanımlanmıştır. Best practices açısından uygun değildir. FluentValidator kullanılarak örnek bir validator yazılmıştır. Autofac ile AOP mantığına çevrilebilir.
- Transaction sistemi kurulmamıştır. UnitOfWork eklenerek geliştirilebilir.
- Dependency Register işlemleri business katmanında extension yazılıp UI katmanından çağrılmıştır.

``` c#
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddDependencyResolvers(Configuration);
    }
```

``` c#
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductImageService, ProductImageService>();
            services.AddScoped<IProductRepository, EfProductRepository>();
            services.AddScoped<IProductImageRepository, EfProductImageRepository>();

            return services;
        }
    }
```
