using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Entity.Entities
{
    public class AppUserLogin:IdentityUserLogin<Guid>
    {
    }
}
