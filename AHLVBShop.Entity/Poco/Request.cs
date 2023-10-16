using AHLVBShop.Entity.Base;
using AHLVBShop.Entity.DTO.OfferDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShop.Entity.Poco
{
    public class Request:BaseEntity
    {
        public Request()
        {
            Offers = new List<Offer>();
        }
        public virtual IEnumerable<Offer> Offers { get; set; }
        public string RequestTitle { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }
        public Product Product { get; set; }
        public Guid ProductId { get; set; }

    }
}
