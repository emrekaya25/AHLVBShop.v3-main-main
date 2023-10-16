using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShop.Entity.DTO.LoginDTO
{
    public class LoginDTOResponse
    {
        public string AdSoyad { get; set; }
        public string EPosta { get; set; }
        public string Token { get; set; }
        public Guid RoleId { get; set; }
        public Guid Id { get; set; }
    }
}
