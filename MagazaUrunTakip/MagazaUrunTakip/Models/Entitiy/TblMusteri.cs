//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MagazaUrunTakip.Models.Entitiy
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TblMusteri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblMusteri()
        {
            this.TblSatislar = new HashSet<TblSatislar>();
        }
    
        public int ID { get; set; }
        [Required(ErrorMessage = "Ad Alanini Bos Gecemezsiniz.")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Soyad Alanini Bos Gecemezsiniz.")]
        public string Soyad { get; set; }
        public string Sehir { get; set; }
        [Required(ErrorMessage = "Bakiye Alanini Bos Gecemezsiniz.")]
        public Nullable<decimal> Bakiye { get; set; }
        public Nullable<bool> Durum { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblSatislar> TblSatislar { get; set; }
    }
}
