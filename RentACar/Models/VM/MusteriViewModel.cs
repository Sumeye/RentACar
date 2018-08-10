using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RentACar.Models.VM
{
    public class MusteriViewModel
    {
         public Musteri Musteri { get; set; }
        //public IEnumerable<iller> il { get; set; }
        //public IEnumerable<ilceler> ilce { get; set; }



        [DisplayName("Adı Soyadı")]
        [Required(ErrorMessage = "{0} boş bırakılamaz.")]
        public string AdiSoyadi { get; set; }

        [DisplayName("Ünvan")]
        public string Unvan { get; set; }

        [Required(ErrorMessage = "{0} boş bırakılamaz.")]
        public string Cinsiyet { get; set; }

        [DisplayName("Doğum Tarihi")]
        public Nullable<System.DateTime> Dogumtarihi { get; set; }

        [DisplayName("TC Kimlik Numarası")]
        [Required(ErrorMessage = "{0} boş bırakılamaz.")]
        public string Tc { get; set; }

        [DisplayName("Vergi Numarası")]
        [Required(ErrorMessage = "{0} boş bırakılamaz.")]
        public string VergiNo { get; set; }

        [DisplayName("Vergi Dairesi")]
        public string VergiDairesi { get; set; }

        [Required(ErrorMessage = "{0} boş bırakılamaz.")]
        public string Adres { get; set; }

        [DisplayName("Ev Telefonu")]
        [Required(ErrorMessage = "{0} boş bırakılamaz.")]
        public string EvTel { get; set; }

        [DisplayName("İş Telefonu")]
        public string istel { get; set; }

        [DisplayName("Cep Telefonu")]
        [Required(ErrorMessage = "{0} boş bırakılamaz.")]
        public string gsm { get; set; }


        public int SehirId { get; set; }
        public int ilceId { get; set; }
        //public string AdiSoyadi { get; set; }
        //public string Unvan { get; set; }
        //public string Cinsiyet { get; set; }
        //public DateTime Dogumtarihi { get; set; }
        //public string Tc { get; set; }
        //public string VergiNo { get; set; }
        //public string VergiDairesi { get; set; }
        //public string Adres { get; set; }
        //public string EvTel { get; set; }
        //public string istel { get; set; }
        //public string gsm { get; set; }

        public SelectList CityData { get; set; }
        public SelectList DistrictData { get; set; }
    }
}