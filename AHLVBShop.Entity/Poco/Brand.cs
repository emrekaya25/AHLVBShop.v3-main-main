using AHLVBShop.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShop.Entity.Poco
{
    public class Brand:BaseEntity
    {
        public Brand()
        {
            Products = new List<Product>();
        }
        public string BrandName { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
