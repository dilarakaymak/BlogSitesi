//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Yorum
    {
        public int id { get; set; }
        public string Baslk { get; set; }
        public string İcerik { get; set; }
        public int MakaleID { get; set; }
        public System.Guid YazarID { get; set; }
        public System.DateTime EklenmeTarihi { get; set; }
    
        public virtual Kulllanici Kulllanici { get; set; }
        public virtual Makale Makale { get; set; }
    }
}
