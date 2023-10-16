using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShop.Entity.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime AddedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
