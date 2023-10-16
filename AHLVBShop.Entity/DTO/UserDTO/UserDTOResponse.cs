using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShop.Entity.DTO.UserDTO
{
    public class UserDTOResponse : UserDTOBase
    {
        public string RoleName { get; set; }
        public Guid RoleId { get; set; }
    }
}
