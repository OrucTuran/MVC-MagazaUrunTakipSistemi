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

    public partial class TblKategori
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblKategori()
        {
            this.TblUrunler = new HashSet<TblUrunler>();
        }

        public int ID { get; set; }
        [Required(ErrorMessage = "Ad Alanini Bos Gecemezsiniz.")]
        [StringLength(30,ErrorMessage ="Kategori ismi 30 karakterden uzun olamaz.")]
        public string Ad { get; set; }
        public Nullable<bool> Durum { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblUrunler> TblUrunler { get; set; }
    }
}
