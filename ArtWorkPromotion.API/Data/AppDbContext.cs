using System;
using ArtWorkPromotion.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArtWorkPromotion.API.Data
{
	public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
	{
        public DbSet<Art> Arts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<AppUser>(entity => { entity.ToTable("AppUsers", "Security"); });
            builder.Entity<AppRole>(entity => { entity.ToTable("AppRoles", "Security"); });
            builder.Entity<IdentityUserClaim<Guid>>(entity => { entity.ToTable("UserClaims", "Security"); });
            builder.Entity<IdentityUserLogin<Guid>>(entity => { entity.ToTable("UserLogins", "Security"); });
            builder.Entity<IdentityRoleClaim<Guid>>(entity => { entity.ToTable("RoleClaims", "Security"); });
            builder.Entity<IdentityUserRole<Guid>>(entity => { entity.ToTable("UserRoles", "Security"); });
            builder.Entity<IdentityUserToken<Guid>>(entity => { entity.ToTable("UserTokens", "Security"); });

        }

        public DbSet<ArtWorkPromotion.API.Models.Social>? Social { get; set; }
    }
}

