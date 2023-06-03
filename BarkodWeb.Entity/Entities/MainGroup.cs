using BarkodWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Entity.Entities
{
    public class MainGroup : EntityBase
    {
        

        public string AnaGrup { get; set; }
        public Guid? ShopId { get; set; }

        public Shop Shop { get; set; }

        public ICollection<LowerGroup> LowerGroups { get; set; }

        public ICollection<Stock> Stocks { get; set; }
        public ICollection<Sale> Sales { get; set; }

    }
}
