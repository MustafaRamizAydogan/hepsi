using BarkodWeb.Core.Entities;
using BarkodWeb.Entity.Entities;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BarkodWeb.Entity.Entities
{
    public class Stock : EntityBase
    {


        
        public string Barkod { get; set; }

        public int Stok { get; set; }

        public int Gram { get; set; }
        public int SatisFiyat { get; set; }
         
        public int AlisFiyat { get; set; }
       
        public string ParaKuru { get; set; }
     
        public string UrunBirimi { get; set; }
       
        public DateTime Tarih { get; set; }= DateTime.Now;

        public Guid MainGroupId { get; set; }

      
        public MainGroup MainGroup{ get; set; }
   
        public Guid LowerGroupId { get; set; }
   
        public LowerGroup LowerGroup { get; set; }

        public Guid ShopId { get; set; }
        public Shop Shop { get; set; }



    }
  
}


