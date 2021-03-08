using System;
using System.Collections.Generic;
using System.Text;

namespace MiniEcommerce.Core.Entity
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime CreatedTime { get; set; }
        DateTime? UpdatedTime { get; set; }
    }
}
