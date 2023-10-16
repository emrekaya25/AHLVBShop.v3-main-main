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
    public class BrandMap:BaseMap<Brand>
    {
        public override void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brand");
            builder.Property(x => x.BrandName).HasMaxLength(255).IsRequired();

            builder.HasMany(x => x.Products).WithOne(x => x.Brand).HasForeignKey(x=>x.BrandId);
        }
    }
}
