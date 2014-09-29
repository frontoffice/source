using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace nTierDAL.DAL
{
    public class BranchDAL
    {
        private FrontOfficeCRMContainer datacontext;
        private static BranchDAL instance;
        public static BranchDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BranchDAL();
                }
                return instance;
            }
        }
        public BranchDAL()
        {
            datacontext = new FrontOfficeCRMContainer();
        }
        public int AddBranch(ArrayList entity)
        {
            tbl_BRANCH tblAddBranch = new tbl_BRANCH();
            tblAddBranch.CompanyId = int.Parse(entity[0].ToString());
            tblAddBranch.AreaId = int.Parse(entity[1].ToString());
            tblAddBranch.Address = entity[2].ToString();
            tblAddBranch.TaxType = entity[3].ToString();
            tblAddBranch.Tax = decimal.Parse(entity[4].ToString());
            tblAddBranch.DiscountType = entity[5].ToString();
            tblAddBranch.Discount = decimal.Parse(entity[6].ToString());
            tblAddBranch.MinOrder = float.Parse(entity[7].ToString());
            tblAddBranch.DeliveryCharge = float.Parse(entity[8].ToString());
            datacontext.tbl_BRANCH.Add(tblAddBranch);
            return datacontext.SaveChanges();
        }
        public int UpdateBranch(ArrayList entity)
        {
            tbl_BRANCH tblUpdateBranch = new tbl_BRANCH();
            tblUpdateBranch.CompanyId = int.Parse(entity[0].ToString());
            tblUpdateBranch.AreaId = int.Parse(entity[1].ToString());
            tblUpdateBranch.Address = entity[2].ToString();
            tblUpdateBranch.TaxType = entity[3].ToString();
            tblUpdateBranch.Tax = decimal.Parse(entity[4].ToString());
            tblUpdateBranch.DiscountType = entity[5].ToString();
            tblUpdateBranch.Discount = decimal.Parse(entity[6].ToString());
            tblUpdateBranch.MinOrder = float.Parse(entity[7].ToString());
            tblUpdateBranch.DeliveryCharge = float.Parse(entity[8].ToString());

            datacontext.tbl_BRANCH.Attach(tblUpdateBranch);
            var entry = datacontext.Entry(tblUpdateBranch);
            entry.Property(b => b.CompanyId).IsModified = true;
            entry.Property(b => b.AreaId).IsModified = true;
            entry.Property(b => b.Address).IsModified = true;
            entry.Property(b => b.TaxType).IsModified = true;
            entry.Property(b => b.Tax).IsModified = true;
            entry.Property(b => b.DiscountType).IsModified = true;
            entry.Property(b => b.Discount).IsModified = true;
            entry.Property(b => b.MinOrder).IsModified = true;
            entry.Property(b => b.DeliveryCharge).IsModified = true;

            return datacontext.SaveChanges();
        }
        public object GetAllBranch()
        {
            return (from b in datacontext.tbl_BRANCH
                    join c in datacontext.tbl_COMPANY on b.CompanyId equals c.CompanyId
                    join a in datacontext.tbl_AREAS on b.AreaId equals a.AeraId
                    select new
                    {
                        b.CompanyId,
                        b.BranchId,
                        Area = a.Area,
                        CompanyName = c.Name,
                        b.Address
                    })
                    .ToList()
                    .OrderBy(b => b.Area);
        }
        public ObjectResult<GetBranchAreaByBranch_Result> GetBranchAreaByBranch(int branchId)
        {
            ObjectResult<GetBranchAreaByBranch_Result> result;
            result = datacontext.GetBranchAreaByBranch(branchId);
            return result;
        }
        public object GetAllBranchesForDropdown()
        {
            return (from b in datacontext.tbl_BRANCH
                    join a in datacontext.tbl_AREAS on b.AreaId equals a.AeraId
                    join c in datacontext.tbl_COMPANY on b.CompanyId equals c.CompanyId
                    select new
                    {
                        b.BranchId,
                        BranchName = string.Concat(c.Name, " - ", a.Area)
                    })
                   .ToList()
                   .OrderBy(b => b.BranchName);
        }
        public object GetBranchById(int branchId)
        {
            return datacontext.tbl_BRANCH
                .Where(b => b.BranchId == branchId)
                .Select(b => new
                {
                    b.BranchId,
                    b.AreaId,
                    b.CompanyId,
                    b.Address
                })
            .FirstOrDefault();
        }
        public object GetBranchsByCompany(int companyId)
        {
            return (from b in datacontext.tbl_BRANCH
                    join a in datacontext.tbl_AREAS on b.AreaId equals a.AeraId
                    where b.CompanyId == companyId
                    select new
                    {
                        b.BranchId,
                        a.Area
                    })
               .ToList()
               .OrderBy(a => a.Area);
        }
        public object GetBranchsByCompanyForOrder(int companyId)
        {
            return datacontext.tbl_BRANCH
                .ToList()
                .Join(datacontext.tbl_AREAS, b => b.AreaId, a => a.AeraId, (b, a) => new
             {
                 Id = string.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}", b.BranchId.ToString(), b.TaxType, b.Tax.ToString(), b.DiscountType, b.Discount.ToString(), b.MinOrder.ToString(), b.DeliveryCharge.ToString()),
                 a.Area,
                 b.CompanyId
             }).Where(b => b.CompanyId == companyId)
             .OrderBy(b => b.Area);
        }
    }
}