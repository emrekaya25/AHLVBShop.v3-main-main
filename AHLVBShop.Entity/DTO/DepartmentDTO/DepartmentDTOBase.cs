using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShop.Entity.DTO.DepartmentDTO
{
    public class DepartmentDTOBase
    {
        public Guid Id { get; set; }
        public string DepartmentName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public Guid CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
