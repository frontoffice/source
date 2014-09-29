using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace nTierDAL.DAL
{
    public class ProductDAL
    {
        private FrontOfficeCRMContainer datacontext;
        private static ProductDAL instance;
        public static ProductDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductDAL();
                }
                return instance;
            }
        }
        public ProductDAL()
        {
            datacontext = new FrontOfficeCRMContainer();
        }
        public int AddProduct(ArrayList entity)
        {
            tbl_PRODUCTS tblAddProduct = new tbl_PRODUCTS();
            tblAddProduct.Name = entity[0].ToString();
            tblAddProduct.CategoryId = int.Parse(entity[1].ToString());
            tblAddProduct.Description = entity[2].ToString();
            tblAddProduct.Price = double.Parse(entity[3].ToString());
            tblAddProduct.UnitSize = entity[4].ToString();
            tblAddProduct.Picture = entity[5].ToString();
            tblAddProduct.IsEnable = bool.Parse(entity[6].ToString());
            datacontext.tbl_PRODUCTS.Add(tblAddProduct);
            return datacontext.SaveChanges();
        }
        public int UpdateProduct(ArrayList entity)
        {
            tbl_PRODUCTS tblUpdateProduct = new tbl_PRODUCTS();
            tblUpdateProduct.Name = entity[0].ToString();
            tblUpdateProduct.CategoryId = int.Parse(entity[1].ToString());
            tblUpdateProduct.Description = entity[2].ToString();
            tblUpdateProduct.Price = double.Parse(entity[3].ToString());
            tblUpdateProduct.UnitSize = entity[4].ToString();
            tblUpdateProduct.Picture = entity[5].ToString();
            tblUpdateProduct.IsEnable = bool.Parse(entity[6].ToString());

            datacontext.tbl_PRODUCTS.Attach(tblUpdateProduct);
            var entry = datacontext.Entry(tblUpdateProduct);
            entry.Property(c => c.Name).IsModified = true;
            entry.Property(c => c.CategoryId).IsModified = true;
            entry.Property(c => c.Description).IsModified = true;
            entry.Property(c => c.Price).IsModified = true;
            entry.Property(c => c.UnitSize).IsModified = true;
            entry.Property(c => c.Picture).IsModified = true;
            entry.Property(c => c.IsEnable).IsModified = true;
            return datacontext.SaveChanges();
        }
        public object GetAllProducts()
        {
            return (from p in datacontext.tbl_PRODUCTS
                    join c in datacontext.tbl_CATEGORY on p.CategoryId equals c.CategoryId
                    join b in datacontext.tbl_BRANCH on c.BranchId equals b.BranchId
                    join comp in datacontext.tbl_COMPANY on b.CompanyId equals comp.CompanyId
                    join a in datacontext.tbl_AREAS on b.AreaId equals a.AeraId
                    select new
                    {
                        Branch = string.Concat(comp.Name, " - ", a.Area),
                        ProductName = p.Name,
                        p.Description,
                        CategoryName = c.Name,
                        p.Price,
                        p.UnitSize,
                        p.IsEnable,
                        p.ProductId,
                        p.Picture
                    })
                   .ToList()
                   .OrderBy(p => p.ProductName);
        }
        public object GetProductById(int productId)
        {
            return datacontext.tbl_PRODUCTS
                .Where(p => p.ProductId == productId)
                .Select(p => new
            {
                p.ProductId,
                p.Name,
                p.CategoryId,
                p.Price,
                p.UnitSize,
                p.IsEnable,
                p.Picture
            })
            .FirstOrDefault();
        }
        public object GetProductByCategory(int categroyId)
        {
            return datacontext.tbl_PRODUCTS
                .Where(p => p.CategoryId == categroyId)
                .ToList()
                .Select(p => new
            {
                ProductIdWithPrice = string.Format("{0}|{1}", p.ProductId, p.Price),
                p.Name
            })
            .OrderBy(p => p.Name);
        }
    }
}