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
    public class EmployeeMap:BaseMap<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employee");
            builder.Property(x=>x.EmployeeFirstName).IsRequired();
            builder.Property(x=>x.EmployeeLastName).IsRequired();
            builder.Property(x=>x.EmployeeUserName).IsRequired();
            builder.Property(x=>x.EmployeePassword).IsRequired();
            builder.Property(x=>x.Phone).IsRequired();
            builder.Property(x=>x.Email).IsRequired();
            builder.Property(x=>x.Address).IsRequired();

            builder.HasMany(x=>x.Requests).WithOne(x=>x.Employee).HasForeignKey(x=>x.EmployeeId);

        }
    }
}
