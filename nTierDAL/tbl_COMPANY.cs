//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace nTierDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_COMPANY
    {
        public tbl_COMPANY()
        {
            this.tbl_BRANCH = new HashSet<tbl_BRANCH>();
            this.tbl_ORDER = new HashSet<tbl_ORDER>();
        }
    
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string NearBy { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public int CityId { get; set; }
        public string StartGreetings { get; set; }
        public string EndGreetings { get; set; }
        public string Logo { get; set; }
    
        public virtual tbl_CITY tbl_CITY { get; set; }
        public virtual ICollection<tbl_BRANCH> tbl_BRANCH { get; set; }
        public virtual ICollection<tbl_ORDER> tbl_ORDER { get; set; }
    }
}
