using BarkodWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarkodWeb.Entity.Entities
{
    public class Report : EntityBase
    {
        

        public string Hasılat { get; set; }

        public bool? Gelir { get; set; }

        public bool? Gider { get; set; }

        public DateTime Tarih { get; set; } = DateTime.Now;

    }
}
