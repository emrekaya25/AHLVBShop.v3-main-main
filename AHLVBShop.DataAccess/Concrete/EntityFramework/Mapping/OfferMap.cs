using AHLVBShop.DataAccess.Concrete.EntityFramework.Mapping.BaseMap;
using AHLVBShop.Entity.Base;
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
    public class OfferMap:BaseMap<Offer>
    {
        public override void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.ToTable("Offer");
            builder.Property(x=>x.OfferDescription).IsRequired();
        }
    }
}
