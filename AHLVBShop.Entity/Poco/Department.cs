using AHLVBShop.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShop.Entity.Poco
{
    public class Department:BaseEntity
    {
        public Department()
        {
            Employees = new List<Employee>();
        }
        public string DepartmentName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }


        public virtual IEnumerable<Employee> Employees { get; set; }
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
    }
}
