using BarkodWeb.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarkodWeb.Data.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            //builder.HasData(
            //    new AppUserRole
            //    {
            //        UserId = Guid.Parse("2E0D82AD-EDB0-4136-AAD3-F925D8645229"),
            //        RoleId = Guid.Parse("8BED9D96-A7DD-4AC6-9AA1-5A62AA289B16")
            //    },
            //     new AppUserRole
            //     {
            //         UserId = Guid.Parse("97605647-E960-4FFD-AFF7-D21948385F88"),
            //         RoleId = Guid.Parse("4C8D723A-FEAC-4FAC-9FAA-13960387D57A")
            //     }
            //    );

        }
    }
}
