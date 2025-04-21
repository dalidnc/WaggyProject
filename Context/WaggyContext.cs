using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WaggyProject.Entities;

namespace WaggyProject.Context
{
    public class WaggyContext: IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-3VF2N1Q\\SQLSERVER2022;database=WaggyDb;integrated security=true;trustServerCertificate=true");
        }


       public DbSet<Banner> Banners { get; set; }
       public DbSet<Product> Products { get; set; }
       public DbSet<Category> Categories { get; set; }
       public DbSet<Testimonial> Testimonials { get; set; }
       public DbSet<ProductView> ProductView { get; set; }
       public DbSet<Message> Messages { get; set; }
       public DbSet<Costume> Costumes { get; set; }
       public DbSet<Gallery> Galleries { get; set; }
       public DbSet<Feature> Features { get; set; }

    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductView>(eb =>
            {
                eb.HasNoKey();
                eb.ToView(nameof(ProductView));
            });
        }
    }
}
