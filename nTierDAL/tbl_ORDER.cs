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
    
    public partial class tbl_ORDER
    {
        public tbl_ORDER()
        {
            this.tbl_ORDER_DETAIL = new HashSet<tbl_ORDER_DETAIL>();
        }
    
        public int OrderID { get; set; }
        public Nullable<int> CallRef { get; set; }
        public int CustomerID { get; set; }
        public int CompanyID { get; set; }
        public int BranchId { get; set; }
        public Nullable<int> OrderCounter { get; set; }
        public string OrderPriority { get; set; }
        public string OrderStatus { get; set; }
        public string OrderType { get; set; }
        public Nullable<System.DateTime> PrintOn { get; set; }
        public Nullable<bool> PrintYN { get; set; }
        public Nullable<System.DateTime> SMSOn { get; set; }
        public Nullable<bool> SMSYN { get; set; }
        public System.Guid OrderCreateBy { get; set; }
        public System.DateTime OrderCreateDateTime { get; set; }
        public Nullable<System.Guid> OrderModifiedBy { get; set; }
        public Nullable<System.DateTime> OrderModifiedDateTime { get; set; }
    
        public virtual aspnet_Employees aspnet_Employees { get; set; }
        public virtual aspnet_Employees aspnet_Employees1 { get; set; }
        public virtual tbl_BRANCH tbl_BRANCH { get; set; }
        public virtual tbl_COMPANY tbl_COMPANY { get; set; }
        public virtual tbl_CUSTOMER tbl_CUSTOMER { get; set; }
        public virtual ICollection<tbl_ORDER_DETAIL> tbl_ORDER_DETAIL { get; set; }
    }
}
