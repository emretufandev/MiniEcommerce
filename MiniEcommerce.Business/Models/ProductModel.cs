using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MiniEcommerce.Business.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ürün adı zorunlu bir alan.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Ürün ismi en az 5 karakter uzunluğunda olmalıdır.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Barkod zorunlu bir alan.")]
        [StringLength(50, ErrorMessage = "Ürün ismi en fazla 50 karakter aralığında olmalıdır.")]
        public string Barcode { get; set; }

         [Required(ErrorMessage="Price zorunlu bir alan.")]  
         [Range(1, 100000,ErrorMessage="Price için 1-10000 arasında değer girmelisiniz.")]
        public decimal Price { get; set; }

        [StringLength(200, ErrorMessage = "Ürün açıklaması en fazla 200 karakter uzuluğunda olmalıdır.")]
        public string Description { get; set; }

        [Range(0, Int32.MaxValue, ErrorMessage = "Stok en az 0 girmelisiniz.")]
        public int Stock { get; set; }
    }
}
