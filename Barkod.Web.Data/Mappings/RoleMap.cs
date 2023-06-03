using BarkodWeb.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarkodWeb.Data.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            // Primary key
            builder.HasKey(r => r.Id);

            // Index for "normalized" role name to allow efficient lookups
            builder.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();

            // Maps to the AspNetRoles table
            builder.ToTable("AspNetRoles");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.Name).HasMaxLength(256);
            builder.Property(u => u.NormalizedName).HasMaxLength(256);

            // The relationships between Role and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each Role can have many entries in the UserRole join table
            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();

            // Each Role can have many associated RoleClaims
            builder.HasMany<AppRoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();

            builder.HasData(new AppRole
            {
                Id = Guid.Parse("8BED9D96-A7DD-4AC6-9AA1-5A62AA289B16"),
                Name = "Superadmin",
                NormalizedName = "SUPERADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()

            },
          

           new AppRole
              {
                  Id = Guid.Parse("CBEFDA7B-7761-42C4-AA47-40C7ED3D04A1"),
                  Name = "Magaza Sahibi",
                  NormalizedName = "MAGAZA SAHİBİ",
                  ConcurrencyStamp = Guid.NewGuid().ToString()

              },

            new AppRole
                {
                    Id = Guid.Parse("E2C488B7-F933-45A1-B8C3-55AE4067879D"),
                    Name = "Personel",
                    NormalizedName = "PERSONEL",
                    ConcurrencyStamp = Guid.NewGuid().ToString()

                }





            );
        }
    }
}
