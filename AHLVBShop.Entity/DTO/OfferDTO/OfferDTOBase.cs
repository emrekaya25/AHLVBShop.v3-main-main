using AHLVBShop.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShop.Entity.DTO.OfferDTO
{
    public class OfferDTOBase
    {
        public Guid Id { get; set; }
        public string OfferDescription { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string RequestName { get; set; }
        public Guid RequestId { get; set; }
    }
}
