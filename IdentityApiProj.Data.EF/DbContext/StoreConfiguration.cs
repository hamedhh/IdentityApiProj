using IdentityApiProj.Data.EF.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityApiProj.Data.EF.DbContext
{
    internal class StoreConfiguration : BaseConfiguration<Store>
    {
        public override void Configure(EntityTypeBuilder<Store> builder)
        {
            base.Configure(builder);

            builder.Property(c => c.Name)
                .HasMaxLength(1034).
                IsRequired(true);


            builder.HasOne(x => x.Category)
                .WithMany(c => c.stories).
                IsRequired().IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            builder.HasIndex(x => x.Name).IsUnique();

        }
    }
}
