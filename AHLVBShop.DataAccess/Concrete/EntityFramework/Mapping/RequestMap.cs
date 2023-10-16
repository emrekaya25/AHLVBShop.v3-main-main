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
    public class RequestMap:BaseMap<Request>
    {
        public override void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.ToTable("Request");
            builder.Property(x=>x.RequestTitle).IsRequired();
            builder.Property(x=>x.Description).IsRequired();

            

            builder.HasMany(x => x.Offers).WithOne(x => x.Request).HasForeignKey(x=>x.RequestId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
