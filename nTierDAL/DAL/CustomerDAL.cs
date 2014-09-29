using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace nTierDAL.DAL
{
    public class CustomerDAL
    {
        private FrontOfficeCRMContainer datacontext;
        private static CustomerDAL instance;
        public static CustomerDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CustomerDAL();
                }
                return instance;
            }
        }
        public CustomerDAL()
        {
            datacontext = new FrontOfficeCRMContainer();
        }
        public int AddCustomer(ArrayList entity)
        {
            tbl_CUSTOMER tblAddCustomer = new tbl_CUSTOMER();
            tblAddCustomer.Name = entity[0].ToString();
            tblAddCustomer.Gender = entity[1].ToString();
            tblAddCustomer.Phone1 = entity[2].ToString();
            tblAddCustomer.Phone2 = entity[3].ToString();
            tblAddCustomer.Phone3 = entity[4].ToString();
            tblAddCustomer.CityId = int.Parse(entity[5].ToString());
            tblAddCustomer.Address1 = entity[6].ToString();
            tblAddCustomer.Address2 = entity[7].ToString();

            datacontext.tbl_CUSTOMER.Add(tblAddCustomer);
            datacontext.SaveChanges();

            return tblAddCustomer.CustomerID;
        }
        public int UpdateCustomer(ArrayList entity)
        {
            tbl_CUSTOMER tblUpdateCustomer = new tbl_CUSTOMER();
            tblUpdateCustomer.Name = entity[0].ToString();
            tblUpdateCustomer.Gender = entity[1].ToString();
            tblUpdateCustomer.Phone1 = entity[2].ToString();
            tblUpdateCustomer.Phone2 = entity[3].ToString();
            tblUpdateCustomer.Phone3 = entity[4].ToString();
            tblUpdateCustomer.CityId = int.Parse(entity[5].ToString());
            tblUpdateCustomer.Address1 = entity[6].ToString();
            tblUpdateCustomer.Address2 = string.IsNullOrEmpty(entity[7].ToString()) ? string.Empty : entity[7].ToString();

            datacontext.tbl_CUSTOMER.Attach(tblUpdateCustomer);
            var entry = datacontext.Entry(tblUpdateCustomer);

            entry.Property(c => c.Name).IsModified = true;
            entry.Property(c => c.Gender).IsModified = true;
            entry.Property(c => c.Phone1).IsModified = true;
            entry.Property(c => c.Phone2).IsModified = true;
            entry.Property(c => c.Phone3).IsModified = true;
            entry.Property(c => c.CityId).IsModified = true;
            entry.Property(c => c.Address1).IsModified = true;
            entry.Property(c => c.Address2).IsModified = true;
            return datacontext.SaveChanges();
        }
        public object GetAllCustomer()
        {
            return (from cus in datacontext.tbl_CUSTOMER
                    join c in datacontext.tbl_CITY on cus.CityId equals c.CityId
                    select new
                    {
                        cus.CustomerID,
                        CustomerName = cus.Name,
                        cus.Gender,
                        cus.CityId,
                        c.City,
                        cus.Address1,
                        cus.Address2,
                        cus.Phone1,
                        cus.Phone2,
                        cus.Phone3
                    })
                    .ToList()
                    .OrderBy(c => c.CustomerName);
        }
        public object GetAllCustomerForDropdown()
        {
            return (from cus in datacontext.tbl_CUSTOMER
                    select new
                    {
                        cus.Name,
                        cus.CustomerID
                    })
                    .ToList()
                    .OrderBy(c => c.Name);
        }
        public object GetCustomerById(int customerId)
        {
            return datacontext.tbl_CUSTOMER
                .Where(c => c.CustomerID == customerId)
                .Select(c => c)
                .FirstOrDefault();
        }
    }
}