﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class FrontOfficeCRMContainer : DbContext
    {
        public FrontOfficeCRMContainer()
            : base("name=FrontOfficeCRMContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<aspnet_Membership> aspnet_Membership { get; set; }
        public DbSet<aspnet_Roles> aspnet_Roles { get; set; }
        public DbSet<tbl_CITY> tbl_CITY { get; set; }
        public DbSet<tbl_COUNTRY> tbl_COUNTRY { get; set; }
        public DbSet<aspnet_Employees> aspnet_Employees { get; set; }
        public DbSet<aspnet_Users> aspnet_Users { get; set; }
        public DbSet<tbl_ORDER_DETAIL> tbl_ORDER_DETAIL { get; set; }
        public DbSet<tbl_CATEGORY> tbl_CATEGORY { get; set; }
        public DbSet<tbl_PRODUCTS> tbl_PRODUCTS { get; set; }
        public DbSet<tbl_CUSTOMER> tbl_CUSTOMER { get; set; }
        public DbSet<tbl_AREAS> tbl_AREAS { get; set; }
        public DbSet<tbl_COMPANY> tbl_COMPANY { get; set; }
        public DbSet<tbl_BRANCH> tbl_BRANCH { get; set; }
        public DbSet<tbl_ORDER> tbl_ORDER { get; set; }
    
        public virtual ObjectResult<GetProductsByCategory_Result> GetProductsByCategory(Nullable<int> cATEGORY_ID)
        {
            var cATEGORY_IDParameter = cATEGORY_ID.HasValue ?
                new ObjectParameter("CATEGORY_ID", cATEGORY_ID) :
                new ObjectParameter("CATEGORY_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProductsByCategory_Result>("GetProductsByCategory", cATEGORY_IDParameter);
        }
    
        public virtual ObjectResult<GetBranchAreaByBranch_Result> GetBranchAreaByBranch(Nullable<int> bRANCH_ID)
        {
            var bRANCH_IDParameter = bRANCH_ID.HasValue ?
                new ObjectParameter("BRANCH_ID", bRANCH_ID) :
                new ObjectParameter("BRANCH_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetBranchAreaByBranch_Result>("GetBranchAreaByBranch", bRANCH_IDParameter);
        }
    }
}
