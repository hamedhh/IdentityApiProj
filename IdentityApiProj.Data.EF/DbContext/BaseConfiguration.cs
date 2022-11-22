using IdentityApiProj.Data.EF.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace IdentityApiProj.Data.EF.DbContext
{
    public abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseModel
    {
        public string Schema { get; set; } = "data";

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(typeof(TEntity).Name, Schema);

            builder.Property(x => x.LastUpdateDate).HasDefaultValueSql("SYSDATETIMEOFFSET()");

        }
    }
}
