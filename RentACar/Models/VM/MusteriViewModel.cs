using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentACar.Models.VM
{
    public class MusteriViewModel
    {
        public IEnumerable<Musteri> Musteri { get; set; }
        public IEnumerable<iller> il { get; set; }
        public IEnumerable<ilceler> ilce { get; set; }


        public int SehirId { get; set; }
        public int ilceId { get; set; }

    }
}