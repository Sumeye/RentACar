using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Models.VM
{
    public class AracViewModel
    {
        public IEnumerable<Marka> Marka { get; set; }
        public IEnumerable<Model> Model { get; set; }
        public IEnumerable<Tip> Tip { get; set; }

        public int AracId { get; set; }
        public int MarkaId { get; set; }
        public string MarkaAdi { get; set; }
        public int ModelId { get; set; }
        public int TipId { get; set; }
        public string Plaka { get; set; }
        public string Renk { get; set; }
        public string ModelYıl { get; set; }
        public decimal GunlukUcret { get; set; }
        public string GunlukUcretBirimi { get; set; }
        public string SasiNo { get; set; }

    }
}