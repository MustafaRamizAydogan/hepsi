using BarkodWeb.Entity.Entities;
using BarkodWeb.Entity.ViewModels.MainGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Entity.ViewModels.Shops
{
    public class ShopViewModel
    {
        public Guid Id { get; set; }
        public string Adı { get; set; }

        public Guid? BossId { get; set; }
        public IList<Shop> shops { get; set; }
    }
}
