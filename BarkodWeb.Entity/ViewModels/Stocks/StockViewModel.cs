using BarkodWeb.Entity.Entities;
using BarkodWeb.Entity.ViewModels.LowerGroups;
using BarkodWeb.Entity.ViewModels.MainGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Entity.ViewModels.Stocks
{
    public class StockViewModel
    {
        public Guid Id { get; set; }
        public string Barkod { get; set; }

        public int Stok { get; set; }

        public int Gram { get; set; }
        public int SatisFiyat { get; set; }

        public int AlisFiyat { get; set; }

        public string ParaKuru { get; set; }
        public string UrunBirimi { get; set; }

        public DateTime Tarih { get; set; }


        public MainGroupViewModel MainGroup { get; set; }

        public LowerGroupViewModel LowerGroup { get; set; }

        


        public Guid ShopId { get; set; }

        public Shop Shop { get; set; }

    }
}
