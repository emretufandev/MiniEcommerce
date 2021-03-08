using System;
using System.Collections.Generic;
using System.Text;

namespace MiniEcommerce.Core.Entity
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
