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
    
    public partial class tbl_BRANCH
    {
        public tbl_BRANCH()
        {
            this.tbl_CATEGORY = new HashSet<tbl_CATEGORY>();
            this.tbl_ORDER = new HashSet<tbl_ORDER>();
        }
    
        public int BranchId { get; set; }
        public int CompanyId { get; set; }
        public Nullable<int> CityId { get; set; }
        public Nullable<int> AreaId { get; set; }
        public string Address { get; set; }
        public string TaxType { get; set; }
        public Nullable<decimal> Tax { get; set; }
        public string DiscountType { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<double> DeliveryCharge { get; set; }
        public Nullable<double> MinOrder { get; set; }
        public Nullable<bool> SmsYN { get; set; }
        public Nullable<int> SmsToOrder { get; set; }
        public Nullable<int> SmsToComplaint { get; set; }
        public Nullable<bool> OrderPrint { get; set; }
        public Nullable<bool> ComplaintPrint { get; set; }
        public Nullable<bool> ReservationPrint { get; set; }
        public Nullable<bool> EnquiryPrint { get; set; }
        public string PrintToIP { get; set; }
        public Nullable<bool> ActiveYN { get; set; }
        public Nullable<int> NumberOfPrint { get; set; }
        public Nullable<int> NumberOfKitchenOrder { get; set; }
        public string SMSNO1 { get; set; }
        public string SMSNO2 { get; set; }
        public string SMSNO3 { get; set; }
        public Nullable<double> OnOrderLaunchSms { get; set; }
        public Nullable<double> OnDispatchSms { get; set; }
        public Nullable<double> OnClosedSms { get; set; }
        public Nullable<double> OnCancelSms { get; set; }
        public Nullable<double> OnComplaintLaunch { get; set; }
        public Nullable<double> OnComplaintProcessSms { get; set; }
        public Nullable<double> OnComplaintResolveSms { get; set; }
        public Nullable<double> SmsOnLaunchReservation { get; set; }
        public Nullable<double> SmsOnConfirmReservation { get; set; }
        public Nullable<double> SmsOnDeclineReservation { get; set; }
        public string OnDispatchSms_Label { get; set; }
        public string OnClosedSms_Label { get; set; }
        public string OnCancelSms_Label { get; set; }
        public string OnComplaintLaunch_Label { get; set; }
        public string OnComplaintProcessSms_Label { get; set; }
        public string OnComplaintResolveSms_Label { get; set; }
        public string SmsOnLaunchReservation_Label { get; set; }
        public string SmsOnConfirmReservation_Label { get; set; }
        public string SmsOnDeclineReservation_Label { get; set; }
    
        public virtual tbl_AREAS tbl_AREAS { get; set; }
        public virtual tbl_CITY tbl_CITY { get; set; }
        public virtual tbl_COMPANY tbl_COMPANY { get; set; }
        public virtual ICollection<tbl_CATEGORY> tbl_CATEGORY { get; set; }
        public virtual ICollection<tbl_ORDER> tbl_ORDER { get; set; }
    }
}
