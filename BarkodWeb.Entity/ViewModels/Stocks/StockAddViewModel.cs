using BarkodWeb.Entity.Entities;
using BarkodWeb.Entity.ViewModels.LowerGroups;
using BarkodWeb.Entity.ViewModels.MainGroups;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using System.Text;
using System.Threading.Tasks;




namespace BarkodWeb.Entity.ViewModels.Stocks
{

  
    public class StockAddViewModel
    {



        public string Barkod { get; set; }

        
        public int Stok { get; set; }





        public int Gram { get; set; }
        public int SatisFiyat { get; set; }

       
        public int AlisFiyat { get; set; }

        public string ParaKuru { get; set; }
        public string UrunBirimi { get; set; }


     
        public string? AltGrup { get; set; }

        public Guid MainGroupId { get ; set; }
        public string? AnaGrup { get; set; }

      
        public LowerGroup LowerGroup { get; set; }
        public IList<MainGroupViewModel> MainGroups { get; set; }
        public Guid LowerGroupId { get; set; }
        public IList<LowerGroupViewModel> lowerGroups { get; set; }






    }
}
