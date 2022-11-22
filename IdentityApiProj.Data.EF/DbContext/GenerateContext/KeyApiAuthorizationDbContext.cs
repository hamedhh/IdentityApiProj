using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;



namespace IdentityApiProj.Data.EF.DbContext
{
    public class KeyApiAuthorizationDbContext<TUser, TRole, TKey> : IdentityDbContext<TUser, TRole, TKey>
    where TUser : IdentityUser<TKey>
    where TRole : IdentityRole<TKey>
    where TKey : IEquatable<TKey>
    {
        public string AuthorizationSchema { get; set; } = "security";

        public KeyApiAuthorizationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TUser>().ToTable("User", AuthorizationSchema);
            modelBuilder.Entity<TRole>().ToTable("Role", AuthorizationSchema);
            modelBuilder.Entity<IdentityUserRole<TKey>>().ToTable("UserRole", AuthorizationSchema);
            modelBuilder.Entity<IdentityUserClaim<TKey>>().ToTable("UserClaim", AuthorizationSchema);
            modelBuilder.Entity<IdentityUserLogin<TKey>>().ToTable("UserLogin", AuthorizationSchema);
            modelBuilder.Entity<IdentityRoleClaim<TKey>>().ToTable("RoleClaim", AuthorizationSchema);
            modelBuilder.Entity<IdentityUserToken<TKey>>().ToTable("UserToken", AuthorizationSchema);


        }
    }
}
