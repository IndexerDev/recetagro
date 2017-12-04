using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace RecetAgro_WS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]        
        [MaxLength(100)]       
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
                        
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Productor> Productores { get; set; }
        public DbSet<Huerto> Huertos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Productor>()
                .ToTable("Productores");

            modelBuilder.Entity<Productor>()
                .Property(p => p.Nombre)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Productor>()
                .Property(p => p.ApellidoPaterno)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Productor>()
                .Property(p => p.ApellidoMaterno)
                .HasMaxLength(50);

            modelBuilder.Entity<Productor>()
                .Property(p => p.Email)
                .HasMaxLength(50);

            modelBuilder.Entity<Productor>()
                .Property(p => p.Telefono)
                .HasMaxLength(50);


            modelBuilder.Entity<Huerto>()
                .ToTable("Huertos");

            modelBuilder.Entity<Huerto>()
                .Property(h => h.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Huerto>()
                .Property(h => h.Sagarpa)
                .HasMaxLength(14)
                .IsRequired();

            modelBuilder.Entity<Huerto>()
                .Property(h => h.Ubicacion)
                .HasMaxLength(30);

            modelBuilder.Entity<Huerto>()
                .Property(h => h.ProductorId)
                .HasColumnName("ProductorId");

            //modelBuilder.Entity<Huerto>()
            //    .HasRequired(h => h.Productor)
            //    .WithMany(h => h.Huertos);








            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}