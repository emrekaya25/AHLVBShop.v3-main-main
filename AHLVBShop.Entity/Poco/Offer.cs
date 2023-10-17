using AHLVBShop.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShop.Entity.Poco
{
    public class Offer:BaseEntity
    {
        public string OfferDescription { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Request Request { get; set; }
        public Guid RequestId { get; set; }
    }
}
