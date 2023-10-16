using AHLVBShop.DataAccess.Concrete.EntityFramework.Mapping.BaseMap;
using AHLVBShop.Entity.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShop.DataAccess.Concrete.EntityFramework.Mapping
{
    public class DepartmentMap:BaseMap<Department>
    {
        public override void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");
            builder.Property(x=>x.DepartmentName).IsRequired();
            builder.Property(x=>x.PhoneNumber);
            builder.Property(x=>x.Address);
            builder.Property(x=>x.Email);

            builder.HasMany(x=>x.Employees).WithOne(x=>x.Department).HasForeignKey(x=>x.DepartmentId);
            
        }
    }
}
