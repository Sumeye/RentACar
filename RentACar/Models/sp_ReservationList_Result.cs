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
    
    public partial class sp_ReservationList_Result
    {
        public int RezervasyonId { get; set; }
        public Nullable<System.DateTime> RezerveTarih { get; set; }
        public Nullable<int> RezerveSure { get; set; }
        public Nullable<System.DateTime> RezerveBitisTarihi { get; set; }
        public Nullable<int> MusteriID { get; set; }
        public Nullable<int> AracID { get; set; }
        public Nullable<decimal> RezerveUcret { get; set; }
        public string RezerveUcretBirimi { get; set; }
    }
}
