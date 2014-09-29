using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nTierDAL;
using nTierDAL.DAL;

using System.Collections;
namespace nTierBLL.BLL
{
    public class CustomerBLL
    {
        private static CustomerBLL instance;
        public static CustomerBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomerBLL();
                }
                return instance;
            }
        }
        public int AddCustomer(CustomerEntity customer)
        {
            ArrayList lstAddCustomer = new ArrayList();
            lstAddCustomer.Add(customer.Name);
            lstAddCustomer.Add(customer.Gender);
            lstAddCustomer.Add(customer.Phone1);
            lstAddCustomer.Add(customer.Phone2);
            lstAddCustomer.Add(customer.Phone3);
            lstAddCustomer.Add(customer.CityId);
            lstAddCustomer.Add(customer.Address1);
            lstAddCustomer.Add(customer.Address2);
            return CustomerDAL.Instance.AddCustomer(lstAddCustomer);
        }
        public int UpdateCustomer(CustomerEntity customer)
        {
            ArrayList lstUpdateCustomer = new ArrayList();
            lstUpdateCustomer.Add(customer.Name);
            lstUpdateCustomer.Add(customer.Gender);
            lstUpdateCustomer.Add(customer.Phone1);
            lstUpdateCustomer.Add(customer.Phone2);
            lstUpdateCustomer.Add(customer.Phone3);
            lstUpdateCustomer.Add(customer.CityId);
            lstUpdateCustomer.Add(customer.Address1);
            lstUpdateCustomer.Add(customer.Address2);
            return CustomerDAL.Instance.UpdateCustomer(lstUpdateCustomer);
        }
        public object GetAllCustomer()
        {
            return CustomerDAL.Instance.GetAllCustomer();
        }
        public object GetAllCustomerForDropdown()
        {
            return CustomerDAL.Instance.GetAllCustomerForDropdown();
        }
        public object GetCustomerById(int customerId)
        {
            return CustomerDAL.Instance.GetCustomerById(customerId);
        }
    }
    public class CustomerEntity
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public int CityId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
    }
}
