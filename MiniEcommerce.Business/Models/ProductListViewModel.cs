using System;
using System.Collections.Generic;
using System.Text;

namespace MiniEcommerce.Business.Models
{
    public class ProductListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public string DefaultImageUrl { get; set; }
    }
}
