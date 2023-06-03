using BarkodWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Entity.Entities
{
    public class Shop : EntityBase
    {
     

        public string Adı { get; set; }

        public Guid? BossId { get; set; }

        public ICollection<AppUser> appUsers { get; set; }
        public ICollection<Stock> Stocks { get; set; }
        public ICollection<Sale> Sales { get; set; }
        public ICollection<LowerGroup> lowerGroups { get; set; }
        public ICollection<MainGroup> mainGroups { get; set; }

        public ICollection<Repair> Repairs { get; set; }


    }
}
