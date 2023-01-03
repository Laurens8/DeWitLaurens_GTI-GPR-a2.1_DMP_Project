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
    
    public partial class Speler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Speler()
        {
            this.Abonnement = new HashSet<Abonnement>();
            this.SpelerClubTornooi = new HashSet<SpelerClubTornooi>();
            this.TerreinReservatie = new HashSet<TerreinReservatie>();
        }
    
        public int Id { get; set; }
        public Nullable<int> ClubID { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Klassement { get; set; }
        public string Geslacht { get; set; }
        public System.DateTime GeboorteDatum { get; set; }
        public string Nationaliteit { get; set; }
        public string Adres { get; set; }
        public string Land { get; set; }
        public string Telefoon { get; set; }
        public string Email { get; set; }
        public string RijksNummer { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Abonnement> Abonnement { get; set; }
        public virtual Club Club { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SpelerClubTornooi> SpelerClubTornooi { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TerreinReservatie> TerreinReservatie { get; set; }
    }
}
