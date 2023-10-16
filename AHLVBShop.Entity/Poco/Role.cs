using AHLVBShop.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShop.Entity.Poco
{
    public class Role:BaseEntity
    {
        public Role()
        {
            Employees = new List<Employee>();
            Users = new List<User>();
        }
        public string RoleName { get; set; }
        public virtual IEnumerable<Employee> Employees { get; set; }
        public virtual IEnumerable<User> Users { get; set; }
    }
}
