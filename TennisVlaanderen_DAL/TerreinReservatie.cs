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
    
    public partial class TerreinReservatie
    {
        public int id { get; set; }
        public int spelerID { get; set; }
        public string terreinNummer { get; set; }
        public string typeOndergrond { get; set; }
        public string typeTennis { get; set; }
    
        public virtual Speler Speler { get; set; }
    }
}
