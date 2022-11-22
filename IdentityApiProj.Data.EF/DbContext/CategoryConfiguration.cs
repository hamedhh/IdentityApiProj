using IdentityApiProj.Data.EF.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityApiProj.Data.EF.DbContext
{
    internal class CategoryConfiguration : BaseConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .HasColumnType("NVARCHAR(1024)")
                .IsRequired();

            builder.HasMany(x=>x.stories)
                .WithOne(x => x.Category)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Childs).WithOne().
                HasForeignKey(x => x.ParentID).
                OnDelete(DeleteBehavior.Restrict);
            


        }
    }
}