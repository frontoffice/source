using System;
using System.Collections;
using System.Linq;
using System.Text;
using nTierDAL.DAL;

namespace nTierBLL.BLL
{
    public class CategoryBLL
    {
        private static CategoryBLL instance;
        public static CategoryBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CategoryBLL();
                }
                return instance;
            }
        }
        public int AddCategory(CategoryEntity entity)
        {
            ArrayList lstAddCategory = new ArrayList();
            lstAddCategory.Add(entity.BranchId);
            lstAddCategory.Add(entity.CategoryName);
            lstAddCategory.Add(entity.Description);            
            return CategoryDAL.Instance.AddCategory(lstAddCategory);
        }
        public int UpdateCategory(CategoryEntity entity)
        {
            ArrayList lstUpdateCategory = new ArrayList();
            lstUpdateCategory.Add(entity.BranchId);
            lstUpdateCategory.Add(entity.CategoryName);
            lstUpdateCategory.Add(entity.Description);            
            return CategoryDAL.Instance.UpdateCategory(lstUpdateCategory);
        }
        public object GetAllCategory()
        {
            return CategoryDAL.Instance.GetAllCategory();
        }
        public object GetCategoryById(int categoryId)
        {
            return CategoryDAL.Instance.GetCategoryById(categoryId);
        }
        public object GetCategoryByBranch(int branchId)
        {
            return CategoryDAL.Instance.GetCategoryByBranch(branchId);
        }
    }
    public class CategoryEntity
    {
        public int BranchId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
