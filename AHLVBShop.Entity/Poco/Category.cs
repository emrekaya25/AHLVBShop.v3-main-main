using AHLVBShop.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShop.Entity.Poco
{
    public class Category:BaseEntity
    {
        public Category()
        {
            Products = new List<Product>();
        }
        public string CategoryName { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
