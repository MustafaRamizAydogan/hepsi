using BarkodWeb.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarkodWeb.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<AppUser>
    {
       

        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            // Primary key
            builder.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

            // Maps to the AspNetUsers table
            builder.ToTable("AspNetUsers");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.UserName).HasMaxLength(256);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            builder.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            builder.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

            //var superadmin = new AppUser
            //{
            //    Id = Guid.Parse("2E0D82AD-EDB0-4136-AAD3-F925D8645229"),
            //    UserName = "superadmin@gmail.com",
            //    NormalizedUserName = "SUPERADMIN@GMAIL.COM",
            //    Email = "superadmin@gmail.com",
            //    NormalizedEmail = "SUPERADMIN@GMAIL.COM",
            //    PhoneNumber = "+095358994827",
            //    Name = "mustafa",
            //    LastName = "aydogan",
                
            //    PhoneNumberConfirmed = true,
            //    EmailConfirmed = true,
            //    SecurityStamp = Guid.NewGuid().ToString()


            //};
            //superadmin.PasswordHash = creatpas(superadmin, "Mraydogan_1998");

        

            //builder.HasData(superadmin);


            //string creatpas(AppUser appUser, string pasword)
            //{
            //    var passwordHaser = new PasswordHasher<AppUser>();
            //    return passwordHaser.HashPassword(appUser, pasword);
            //}




        }

    }

}
