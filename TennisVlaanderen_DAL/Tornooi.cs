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
    
    public partial class Tornooi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tornooi()
        {
            this.SpelerClubTornooi = new HashSet<SpelerClubTornooi>();
        }
    
        public int Id { get; set; }
        public string NaamTornooi { get; set; }
        public System.DateTime Datum { get; set; }
        public string Circuit { get; set; }
        public string TypeCompetitie { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SpelerClubTornooi> SpelerClubTornooi { get; set; }
    }
}
