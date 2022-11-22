using IdentityApiProj.Data.EF.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityApiProj.Data.EF.DbContext
{
    public class ApplicationDbContext : KeyApiAuthorizationDbContext<User, Role, int>
    {

        public ApplicationDbContext() : base(null) { }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Category> stories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new CategoryConfiguration().Configure(modelBuilder.Entity<Category>());

            new StoreConfiguration().Configure(modelBuilder.Entity<Store>());
        }

        internal virtual void SetUpdateConfig<TEntity>(TEntity item) where TEntity : BaseModel
        {
            item.LastUpdateDate = DateTimeOffset.Now;
            if (item is BaseUserDataModel userDataModel)
                this.Entry(userDataModel).Property(s => s.UserId).IsModified = false;
            this.Entry(item).Property(s => s.CreateDate).IsModified = false;
        }
    }
}
