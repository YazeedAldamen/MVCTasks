//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace task_13th_feb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Major
    {
        public int Id { get; set; }
        public string Major1 { get; set; }
        public Nullable<int> FacilityID { get; set; }
    
        public virtual Facility Facility { get; set; }
    }
}
