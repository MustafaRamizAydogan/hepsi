using BarkodWeb.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Entity.ViewModels.Users
{
    public class UserAddViewModel
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }


        public Guid ShopId { get; set; }

        public Guid RoleId { get; set; }

        public List<AppRole> appRoles { get; set; }

        public List<Shop> shops { get; set; }

    }
}
