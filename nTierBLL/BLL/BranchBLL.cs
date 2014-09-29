using System;
using System.Collections;
using System.Linq;
using System.Text;
using nTierDAL.DAL;
using System.Data.Objects;
using nTierDAL;

namespace nTierBLL.BLL
{
    public class BranchBLL
    {
        private static BranchBLL instance;
        public static BranchBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BranchBLL();
                }
                return instance;
            }
        }
        public int AddBranch(BranchEntity entity)
        {
            ArrayList lstAddBranch = new ArrayList();
            lstAddBranch.Add(entity.CompanyId);
            lstAddBranch.Add(entity.AreaId);
            lstAddBranch.Add(entity.Address);
            lstAddBranch.Add(entity.TaxType);
            lstAddBranch.Add(entity.Tax);
            lstAddBranch.Add(entity.DiscountType);
            lstAddBranch.Add(entity.Discount);
            lstAddBranch.Add(entity.MinOrder);
            lstAddBranch.Add(entity.DeliveryCharges);
            return BranchDAL.Instance.AddBranch(lstAddBranch);
        }
        public int UpdateBranch(BranchEntity entity)
        {
            ArrayList lstUpdateBranch = new ArrayList();
            lstUpdateBranch.Add(entity.CompanyId);
            lstUpdateBranch.Add(entity.AreaId);
            lstUpdateBranch.Add(entity.Address);
            lstUpdateBranch.Add(entity.TaxType);
            lstUpdateBranch.Add(entity.Tax);
            lstUpdateBranch.Add(entity.DiscountType);
            lstUpdateBranch.Add(entity.Discount);
            lstUpdateBranch.Add(entity.MinOrder);
            lstUpdateBranch.Add(entity.DeliveryCharges);
            return BranchDAL.Instance.UpdateBranch(lstUpdateBranch);
        }
        public object GetAllBranch()
        {
            return BranchDAL.Instance.GetAllBranch();
        }
        public object GetAllBranchesForDropdown()
        {
            return BranchDAL.Instance.GetAllBranchesForDropdown();
        }
        public object GetBranchById(int branchId)
        {
            return BranchDAL.Instance.GetBranchById(branchId);
        }
        public object GetBranchsByCompany(int companyId)
        {
            return BranchDAL.Instance.GetBranchsByCompany(companyId);
        }
        public object GetBranchsByCompanyForOrder(int companyId)
        {
            return BranchDAL.Instance.GetBranchsByCompanyForOrder(companyId);
        }
        public ObjectResult<GetBranchAreaByBranch_Result> GetBranchAreaByBranch(int branchId)
        {
            return BranchDAL.Instance.GetBranchAreaByBranch(branchId);
        }
    }
    public class BranchEntity
    {
        public int BranchId { get; set; }
        public int CompanyId { get; set; }
        public int AreaId { get; set; }
        public string Address { get; set; }
        public string TaxType { get; set; }
        public decimal Tax { get; set; }
        public string DiscountType { get; set; }
        public decimal Discount { get; set; }
        public float MinOrder { get; set; }
        public float DeliveryCharges { get; set; }
    }
}
