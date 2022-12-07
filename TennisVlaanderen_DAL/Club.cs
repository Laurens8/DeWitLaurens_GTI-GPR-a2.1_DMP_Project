//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TennisVlaanderen_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Club
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Club()
        {
            this.Abonnement = new HashSet<Abonnement>();
            this.Tarieven = new HashSet<Tarieven>();
            this.SpelerClubTornooi = new HashSet<SpelerClubTornooi>();
        }
    
        public int id { get; set; }
        public string naam { get; set; }
        public string adres { get; set; }
        public string telefoon { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        public string kwaliteitLabel { get; set; }
        public string clubaanbod { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Abonnement> Abonnement { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tarieven> Tarieven { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SpelerClubTornooi> SpelerClubTornooi { get; set; }
    }
}
