using BarkodWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Entity.Entities
{
    public class LowerGroup : EntityBase
    {
     

        public string AltGrup { get; set; }

        public Guid? ShopId { get; set; }

        public Shop Shop { get; set; }



        public Guid MainGroupId { get; set; }

        public MainGroup MainGroup { get; set; }


        public ICollection<Stock> Stocks { get; set; }
        public ICollection<Sale> Sales { get; set; }

    }
}
