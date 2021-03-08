using MiniEcommerce.Core.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MiniEcommerce.Entity
{
    public class Product : BaseEntity
    {
        public Product()
        {
            ProductImages = new List<ProductImage>();
        }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }

        public List<ProductImage> ProductImages { get; set; }
    }
}
