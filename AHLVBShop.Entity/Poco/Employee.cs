using AHLVBShop.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShop.Entity.Poco
{
    public class Employee:BaseEntity
    {
        public Employee()
        {
            Requests = new List<Request>();
        }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeUserName { get; set; }
        public string EmployeePassword { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public Department Department { get; set; }
        public Guid DepartmentId { get; set; }
        public Role Role { get; set; }
        public Guid RoleId { get; set; }
        public virtual IEnumerable<Request> Requests { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
