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
    public class UserMap:BaseMap<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.Property(x=>x.UserName).IsRequired();
            builder.Property(x=>x.UserFirstName).IsRequired();
            builder.Property(x=>x.UserLastName).IsRequired();
            builder.Property(x=>x.Password).IsRequired();
            builder.Property(x=>x.Email).IsRequired();

            builder.Property(x => x.RoleId).HasDefaultValue(Guid.Parse("ea7a5630-c7c0-46f0-a026-c395716077a0"));

            builder.HasMany(x=>x.Offers).WithOne(x=>x.User).HasForeignKey(x=>x.UserId);
        }
    }
}
