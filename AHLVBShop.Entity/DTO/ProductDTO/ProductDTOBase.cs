using AHLVBShop.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShop.Entity.DTO.ProductDTO
{
    public class ProductDTOBase
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }


        public Guid BrandId { get; set; }
        public string BrandName { get; set; }
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
