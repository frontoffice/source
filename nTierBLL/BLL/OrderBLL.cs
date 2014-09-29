using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nTierDAL;
using nTierDAL.DAL;

using System.Collections;
namespace nTierBLL.BLL
{
    public class OrderBLL
    {
        private static OrderBLL instance;
        public static OrderBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new OrderBLL();
                }
                return instance;
            }
        }
        public int AddOrder(tbl_ORDER entity)
        {
            return OrderDAL.Instance.AddOrder(entity);
        }
        public int AddOrderDetail(OrderDetailEntity orderDetail)
        {
            ArrayList lstAddOrderDetail = new ArrayList();
            lstAddOrderDetail.Add(orderDetail.OrderId);
            lstAddOrderDetail.Add(orderDetail.ProductId);
            lstAddOrderDetail.Add(orderDetail.TaxAmount);
            lstAddOrderDetail.Add(orderDetail.ProductUnitSize);
            lstAddOrderDetail.Add(orderDetail.Quantity);
            lstAddOrderDetail.Add(orderDetail.Discount);
            return OrderDAL.Instance.AddOrderDetail(lstAddOrderDetail);
        }
        public object GetAllOrders()
        {
            return OrderDAL.Instance.GetAllOrders();
        }
        public object GetOrderById(int customerId)
        {
            return OrderDAL.Instance.GetOrderById(customerId);
        }
    }
    public class OrderEntity
    {
        public int? CallRef { get; set; }
        public int CustomerID { get; set; }
        public int CompanyID { get; set; }
        public int BranchAreaID { get; set; }
        public int OrderCounter { get; set; }
        public string OrderPriority { get; set; }
        public string OrderStatus { get; set; }
        public string OrderType { get; set; }
        public DateTime? PrintOn { get; set; }
        public bool? PrintYN { get; set; }
        public DateTime? SMSOn { get; set; }
        public bool? SMSYN { get; set; }
        public Guid OrderCreateBy { get; set; }
        public DateTime OrderCreateDateTime { get; set; }
        public Guid? OrderModifiedBy { get; set; }
    }
    public class OrderDetailEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int TaxAmount { get; set; }
        public int ProductUnitSize { get; set; }
        public int Quantity { get; set; }
        public int? Discount { get; set; }
    }
}
