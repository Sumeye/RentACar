using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Models.VM
{
    public class RezervasyonViewModel
    {
        public IEnumerable<Musteri> Musteri { get; set; }
        public IEnumerable<Arac> Arac { get; set; }

        public int MusteriId { get; set; }
        public int AracId { get; set; }
        public string MusteriAdi { get; set; }
        public string Plaka { get; set; }
    }
}