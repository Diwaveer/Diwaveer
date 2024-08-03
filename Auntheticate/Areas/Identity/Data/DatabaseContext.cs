using Auntheticate.Areas.Identity.Data;
using Auntheticate.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auntheticate.Areas.Identity.Data;

public class DatabaseContext : IdentityDbContext<ApplicationUser>
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }
    public DbSet<Category>Categories { get; set; }
    public DbSet<Product> Products { get; set; }
}

//protected override void OnModelCreating(ModelBuilder builder)
//{
//    base.OnModelCreating(builder);
//    //Customize the ASP.NET Identity model and override the defaults if needed.
//    // For example, you can rename the ASP.NET Identity table names and more.
//    // Add your customizations after calling base.OnModelCreating(builder);

//    builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());

//    builder.Entity<ApplicationUser>().Property(u => u.FirstName).IsRequired().HasMaxLength(50);
//    builder.Entity<ApplicationUser>().Property(u => u.LastName).IsRequired().HasMaxLength(50);

//}

//}
//public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
//{
//    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
//    {
//        builder.property(u => u.FirstName).HasMaxLength(255);
//        builder.property(u => u.LastName).HasMaxLength(255);
//    }

