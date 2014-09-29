using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace nTierDAL.DAL
{
    public class CategoryDAL
    {
        private FrontOfficeCRMContainer datacontext;
        private static CategoryDAL instance;
        public static CategoryDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CategoryDAL();
                }
                return instance;
            }
        }
        public CategoryDAL()
        {
            datacontext = new FrontOfficeCRMContainer();
        }
        public int AddCategory(ArrayList entity)
        {
            tbl_CATEGORY tblCategory = new tbl_CATEGORY();
            tblCategory.BranchId = int.Parse(entity[0].ToString());
            tblCategory.Name = entity[1].ToString();
            tblCategory.Description = entity[2].ToString();
            datacontext.tbl_CATEGORY.Add(tblCategory);
            return datacontext.SaveChanges();
        }
        public int UpdateCategory(ArrayList entity)
        {
            tbl_CATEGORY tblCategory = new tbl_CATEGORY();
            tblCategory.BranchId = int.Parse(entity[0].ToString());
            tblCategory.Name = entity[1].ToString();
            tblCategory.Description = entity[2].ToString();

            datacontext.tbl_CATEGORY.Attach(tblCategory);
            var entry = datacontext.Entry(tblCategory);
            entry.Property(c => c.BranchId).IsModified = true;
            entry.Property(c => c.Name).IsModified = true;
            entry.Property(c => c.Description).IsModified = true;

            return datacontext.SaveChanges();
        }
        public object GetAllCategory()
        {
            return (from c in datacontext.tbl_CATEGORY
                    join b in datacontext.tbl_BRANCH on c.BranchId equals b.BranchId
                    join a in datacontext.tbl_AREAS on b.AreaId equals a.AeraId
                    join comp in datacontext.tbl_COMPANY on b.CompanyId equals comp.CompanyId
                    select new
                    {
                        c.CategoryId,
                        c.Name,
                        c.Description,
                        BranchName = string.Concat(comp.Name, " - ", a.Area)
                    })
                   .ToList()
                   .OrderBy(c => c.Name);
        }
        public object GetCategoryByBranches(int branchId)
        {
            return (from c in datacontext.tbl_CATEGORY
                    where c.BranchId == branchId
                    select new
                    {
                        c.CategoryId,
                        c.Name
                    })
                   .ToList()
                   .OrderBy(c => c.Name);
        }
        public object GetCategoryById(int categoryId)
        {
            return datacontext.tbl_CATEGORY
                .Where(c => c.CategoryId == categoryId)
                .Select(c => new
            {
                c.CategoryId,
                c.BranchId,
                c.Name,
                c.Description,
            })
            .FirstOrDefault();
        }
        public object GetCategoryByBranch(int branchId)
        {
            return datacontext.tbl_CATEGORY
                .Where(c => c.BranchId == branchId)
                .Select(c => new
                {
                    c.CategoryId,
                    c.Name
                })
                .ToList()
                .OrderBy(c => c.Name);
        }
    }
}