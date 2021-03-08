using FluentValidation;
using MiniEcommerce.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniEcommerce.Business.ValidationRules
{
    public class ProductValidator : AbstractValidator<ProductModel>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün adı zorunlu bir alan.");
            RuleFor(x => x.Name).Length(5, 50).WithMessage("Ürün ismi en az 5 karakter uzunluğunda olmalıdır.");

            RuleFor(x => x.Barcode).NotEmpty().WithMessage("Ürün barkodu zorunlu bir alan.");
            RuleFor(x => x.Barcode).Length(5, 50).WithMessage("Ürün barkodu en az 5 karakter uzunluğunda olmalıdır.");

            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Ürün fiyatı için 0'dan büyük değer girmelisiniz.");

            RuleFor(x => x.Description).MaximumLength(200).WithMessage("Ürün açıklaması en fazla 200 karakter uzuluğunda olmalıdır.");

            RuleFor(x => x.Stock).GreaterThanOrEqualTo(0).WithMessage("Stok en az 0 girmelisiniz.");
        }
    }
}
