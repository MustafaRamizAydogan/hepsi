using BarkodWeb.Core.Entities;

namespace BarkodWeb.Entity.Entities
{
    public class Repair : EntityBase
    {
        public string Isim { get; set; }

        public int Tel { get; set; }

        public string UrunTuru { get; set; }

        public string Islem { get; set; }

        public int Masraf { get; set; }

        public int Adet { get; set; }

        public int Fiyat { get; set; }

        public string ImageName { get; set; }
        public string ImageType { get; set; }


        public Guid? ShopId { get; set; }

        public Shop Shop { get; set; }

    }
}
