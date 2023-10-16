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
    public class ProductMap:BaseMap<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.Property(x=>x.ProductName).IsRequired();
            builder.Property(x=>x.Price).IsRequired();
            builder.Property(x=>x.Description).IsRequired();
            builder.Property(x=>x.Quantity).HasDefaultValue(0).IsRequired();


            builder.HasMany(x=>x.Requests).WithOne(x=>x.Product).HasForeignKey(x=>x.ProductId);
        }
    }
}
