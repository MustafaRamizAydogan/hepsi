using BarkodWeb.Core.Entities;
using BarkodWeb.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Entity.Entities
{
    public class Sale : EntityBase
    {


        public string Barkod { get; set; }

        public int SatılanStok { get; set; }

        public int Gram { get; set; }
        public int SatisFiyat { get; set; }

        public int AlisFiyat { get; set; }

        public string ParaKuru { get; set; }
        public string UrunBirimi { get; set; }

        public DateTime SatisTarih { get; set; }

        public int Hasılat { get; set; }

        public string OdemeTuru { get; set; }

        public Guid? MainGroupId { get; set; }
        public MainGroup MainGroup { get; set; }
        public Guid? LowerGroupId { get; set; }

        public LowerGroup LowerGroup { get; set; }


        public Guid? ShopId { get; set; }

        public Shop Shop { get; set; }

    }
}
