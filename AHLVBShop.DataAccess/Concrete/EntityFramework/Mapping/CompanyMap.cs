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
    public class CompanyMap:BaseMap<Company>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company");
            builder.Property(x=>x.CompanyName).IsRequired();
            builder.Property(x=>x.Address).IsRequired();
            builder.Property(x=>x.Email).IsRequired();
            builder.Property(x=>x.Phone).IsRequired();

            builder.HasMany(x=>x.Departments).WithOne(x=>x.Company).HasForeignKey(x=>x.CompanyId);

            builder.HasMany(x => x.Employees).WithOne(x => x.Company).HasForeignKey(x=>x.CompanyId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
