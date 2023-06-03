using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Entity.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public Guid? BossId { get; set; }


        public Guid? ShopId { get; set; }

        public Shop Shop { get; set; }
    }
}
