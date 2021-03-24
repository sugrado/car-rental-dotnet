using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Brand : IEntity
    {
        public string BrandName { get; set; }
        public int BrandId { get; set; }
    }
}
