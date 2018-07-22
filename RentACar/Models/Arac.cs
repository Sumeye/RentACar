//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentACar.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Arac
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Arac()
        {
            this.Rezervasyon = new HashSet<Rezervasyon>();
        }
    
        public int AracId { get; set; }
        public Nullable<int> MarkaID { get; set; }
        public Nullable<int> ModelID { get; set; }
        public Nullable<int> TipID { get; set; }
        public string Plaka { get; set; }
        public string SasiNo { get; set; }
        public string Renk { get; set; }
        public string ModelYıl { get; set; }
        public Nullable<decimal> GunlukUcret { get; set; }
        public string GunlukUcretBirimi { get; set; }
    
        public virtual Marka Marka { get; set; }
        public virtual Model Model { get; set; }
        public virtual Tip Tip { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rezervasyon> Rezervasyon { get; set; }
    }
}
