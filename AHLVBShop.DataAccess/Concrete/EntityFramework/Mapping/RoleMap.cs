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
    public class RoleMap:BaseMap<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.Property(x => x.RoleName).IsRequired();
            

            builder.HasMany(x=>x.Employees).WithOne(x=>x.Role).HasForeignKey(x=>x.RoleId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x=>x.Users).WithOne(x=>x.Role).HasForeignKey(x=>x.RoleId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
