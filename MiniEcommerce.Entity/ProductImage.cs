using MiniEcommerce.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniEcommerce.Entity
{
    public class ProductImage : BaseEntity
    {
        public int ProductId { get; set; }
        public string Url { get; set; }

        public virtual Product Product { get; set; }
    }
}
