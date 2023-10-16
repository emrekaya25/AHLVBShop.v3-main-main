using AHLVBShop.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShop.Entity.DTO.BrandDTO
{
    public class BrandDTOBase
    {
        public Guid Id { get; set; }
        public string BrandName { get; set; }
    }
}
