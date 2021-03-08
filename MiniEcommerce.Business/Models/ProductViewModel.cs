using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MiniEcommerce.Business.Models
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            ProductImages = new List<ProductImageViewModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }

        public List<ProductImageViewModel> ProductImages { get; set; }
    }
}
