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
    
    public partial class tbl_CITY
    {
        public tbl_CITY()
        {
            this.aspnet_Employees = new HashSet<aspnet_Employees>();
            this.tbl_AREAS = new HashSet<tbl_AREAS>();
            this.tbl_COMPANY = new HashSet<tbl_COMPANY>();
            this.tbl_BRANCH = new HashSet<tbl_BRANCH>();
        }
    
        public int CityId { get; set; }
        public int CountryId { get; set; }
        public string City { get; set; }
    
        public virtual tbl_COUNTRY tbl_COUNTRY { get; set; }
        public virtual ICollection<aspnet_Employees> aspnet_Employees { get; set; }
        public virtual ICollection<tbl_AREAS> tbl_AREAS { get; set; }
        public virtual ICollection<tbl_COMPANY> tbl_COMPANY { get; set; }
        public virtual ICollection<tbl_BRANCH> tbl_BRANCH { get; set; }
    }
}
