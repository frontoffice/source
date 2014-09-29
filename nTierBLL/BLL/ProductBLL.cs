using System;
using System.Collections;
using System.Linq;
using System.Text;
using nTierDAL.DAL;
using System.Data.Objects;
using nTierDAL;

namespace nTierBLL.BLL
{
    public class ProductBLL
    {
        private static ProductBLL instance;
        public static ProductBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductBLL();
                }
                return instance;
            }
        }
        public int AddProduct(ProductEntity entity)
        {
            ArrayList lstAddProduct = new ArrayList();
            lstAddProduct.Add(entity.ProductName);
            lstAddProduct.Add(entity.CategoryId);
            lstAddProduct.Add(entity.Description);
            lstAddProduct.Add(entity.Price);
            lstAddProduct.Add(entity.UnitSize);
            lstAddProduct.Add(entity.Picture);
            lstAddProduct.Add(entity.IsEnabled);
            return ProductDAL.Instance.AddProduct(lstAddProduct);
        }
        public int UpdateProduct(ProductEntity entity)
        {
            ArrayList lstUpdateProduct = new ArrayList();
            lstUpdateProduct.Add(entity.ProductName);
            lstUpdateProduct.Add(entity.CategoryId);
            lstUpdateProduct.Add(entity.Description);
            lstUpdateProduct.Add(entity.Price);
            lstUpdateProduct.Add(entity.UnitSize);
            lstUpdateProduct.Add(entity.Picture);
            lstUpdateProduct.Add(entity.IsEnabled);
            return ProductDAL.Instance.UpdateProduct(lstUpdateProduct);
        }
        public object GetAllProduct()
        {
            return ProductDAL.Instance.GetAllProducts();
        }
        public object GetCategoryById(int productId)
        {
            return ProductDAL.Instance.GetProductById(productId);
        }
        public object GetProductByCategory(int categroyId)
        {
            return ProductDAL.Instance.GetProductByCategory(categroyId);
        }
    }
    public class ProductEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int UnitSize { get; set; }
        public string Picture { get; set; }
        public bool IsEnabled { get; set; }
    }
}
