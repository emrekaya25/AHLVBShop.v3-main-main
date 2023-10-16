using AHLVBShop.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShop.Entity.Poco
{
    public class Company:BaseEntity
    {
        public Company()
        {
            Departments = new List<Department>();
            Employees = new List<Employee>();
        }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }


        public virtual IEnumerable<Employee> Employees { get; set; }
        public virtual IEnumerable<Department> Departments { get; set; }
    }
}
