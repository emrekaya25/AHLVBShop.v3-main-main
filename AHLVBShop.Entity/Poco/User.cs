using AHLVBShop.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShop.Entity.Poco
{
    public class User:BaseEntity
    {
        public User()
        {
            Offers = new List<Offer>();
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }


        public Role Role { get; set; }
        public Guid RoleId { get; set; }
        public virtual IEnumerable<Offer> Offers { get; set; }
    }
}
