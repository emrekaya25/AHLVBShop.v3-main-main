using AHLVBShop.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShop.Entity.Poco
{
    public class Product:BaseEntity
    {
        public Product()
        {
            Requests = new List<Request>();
        }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }


        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public Brand Brand { get; set; }
        public Guid BrandId { get; set; }
        public virtual IEnumerable<Request> Requests { get; set; }
    }
}
