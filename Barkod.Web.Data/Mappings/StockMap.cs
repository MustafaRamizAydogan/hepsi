using BarkodWeb.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Data.Mappings
{
    
    public class StockMap : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {   // burada table içerigini kaç deger alacagını büyük harf vs gibi null yapma vs
            //builder.Property(x=> x.MainGroupId)
        }
    }
}
