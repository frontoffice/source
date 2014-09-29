using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace nTierDAL.DAL
{
    public class OrderDAL
    {
        private FrontOfficeCRMContainer datacontext;
        private static OrderDAL instance;
        public static OrderDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderDAL();
                }
                return instance;
            }
        }
        public OrderDAL()
        {
            datacontext = new FrontOfficeCRMContainer();
        }
        public int AddOrder(tbl_ORDER entity)
        {
            datacontext.tbl_ORDER.Add(entity);
            return datacontext.SaveChanges();
        }
        public int AddOrderDetail(ArrayList entity)
        {
            tbl_ORDER tblAddOrder = new tbl_ORDER();
            tbl_ORDER_DETAIL tblAddOrderDetail = new tbl_ORDER_DETAIL();
            tblAddOrderDetail.OrderId = !string.IsNullOrEmpty(entity[0].ToString()) ? int.Parse(entity[0].ToString()) : 0;
            tblAddOrderDetail.ProductId = int.Parse(entity[1].ToString());
            tblAddOrderDetail.TaxAmount = float.Parse(entity[2].ToString());
            tblAddOrderDetail.ProductUnitSize = int.Parse(entity[3].ToString());
            tblAddOrderDetail.Quantity = int.Parse(entity[4].ToString());
            tblAddOrderDetail.Discount = int.Parse(entity[5].ToString());

            tblAddOrder.tbl_ORDER_DETAIL.Add(tblAddOrderDetail);
            return datacontext.SaveChanges();
        }
        //public int UpdateOrder(ArrayList entity)
        // {
        //tbl_COMPANY tblUpdateCompany = new tbl_COMPANY();
        //tblUpdateCompany.Name = entity[0].ToString();
        //tblUpdateCompany.Address = entity[1].ToString();
        //tblUpdateCompany.NearBy = entity[2].ToString();
        //tblUpdateCompany.Phone1 = int.Parse(entity[3].ToString());
        //tblUpdateCompany.Phone2 = int.Parse(entity[4].ToString());
        //tblUpdateCompany.Phone3 = int.Parse(entity[5].ToString());
        //tblUpdateCompany.CityId = int.Parse(entity[6].ToString());
        //tblUpdateCompany.MinOrder = int.Parse(entity[7].ToString());
        //tblUpdateCompany.StartGreetings = entity[8].ToString();
        //tblUpdateCompany.EndGreetings = entity[9].ToString();
        //tblUpdateCompany.Logo = entity[10].ToString();

        //datacontext.tbl_COMPANY.Attach(tblUpdateCompany);
        //var entry = datacontext.Entry(tblUpdateCompany);

        //entry.Property(c => c.Name).IsModified = true;
        //entry.Property(c => c.Address).IsModified = true;
        //entry.Property(c => c.NearBy).IsModified = true;
        //entry.Property(c => c.Phone1).IsModified = true;
        //entry.Property(c => c.Phone2).IsModified = true;
        //entry.Property(c => c.Phone3).IsModified = true;
        //entry.Property(c => c.CityId).IsModified = true;
        //entry.Property(c => c.MinOrder).IsModified = true;
        //entry.Property(c => c.StartGreetings).IsModified = true;
        //entry.Property(c => c.EndGreetings).IsModified = true;
        //entry.Property(c => c.Logo).IsModified = true;

        //return datacontext.SaveChanges();
        // }
        public object GetAllOrders()
        {
            return (from o in datacontext.tbl_ORDER
                    join c in datacontext.tbl_CUSTOMER on o.CustomerID equals c.CustomerID
                    join cm in datacontext.tbl_COMPANY on o.CompanyID equals cm.CompanyId
                    join b in datacontext.tbl_BRANCH on o.BranchId equals b.BranchId
                    join a in datacontext.tbl_AREAS on b.AreaId equals a.AeraId
                    select new
                    {
                        o.OrderID,
                        o.CompanyID,
                        o.CustomerID,
                        o.BranchId,
                        o.OrderCreateBy,
                        o.OrderCreateDateTime,
                        o.OrderModifiedBy,
                        o.OrderModifiedDateTime,
                        CustomerName = c.Name,
                        CompanyName = cm.Name,
                        a.Area
                    })
                    .ToList()
                    .OrderBy(c => c.OrderCreateDateTime);
        }
        public object GetOrderById(int companyId)
        {
            return datacontext.tbl_COMPANY
                .Where(c => c.CompanyId == companyId)
                .Select(c => c)
                .FirstOrDefault();
        }
    }
}