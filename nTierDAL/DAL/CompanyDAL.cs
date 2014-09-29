using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace nTierDAL.DAL
{
    public class CompanyDAL
    {
        private FrontOfficeCRMContainer datacontext;
        private static CompanyDAL instance;
        public static CompanyDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CompanyDAL();
                }
                return instance;
            }
        }
        public CompanyDAL()
        {
            datacontext = new FrontOfficeCRMContainer();
        }
        public int AddCompany(ArrayList entity)
        {
            tbl_COMPANY tblAddCompany = new tbl_COMPANY();
            tblAddCompany.Name = entity[0].ToString();
            tblAddCompany.Address = entity[1].ToString();
            tblAddCompany.NearBy = entity[2].ToString();
            tblAddCompany.Phone1 = entity[3].ToString();
            tblAddCompany.Phone2 = entity[4].ToString();
            tblAddCompany.Phone3 = entity[5].ToString();
            tblAddCompany.CityId = int.Parse(entity[6].ToString());
            tblAddCompany.StartGreetings = entity[7].ToString();
            tblAddCompany.EndGreetings = entity[8].ToString();
            tblAddCompany.Logo = entity[9].ToString();

            datacontext.tbl_COMPANY.Add(tblAddCompany);
            return datacontext.SaveChanges();
        }
        public int UpdateCompany(ArrayList entity)
        {
            tbl_COMPANY tblUpdateCompany = new tbl_COMPANY();
            tblUpdateCompany.Name = entity[0].ToString();
            tblUpdateCompany.Address = entity[1].ToString();
            tblUpdateCompany.NearBy = entity[2].ToString();
            tblUpdateCompany.Phone1 = entity[3].ToString();
            tblUpdateCompany.Phone2 = entity[4].ToString();
            tblUpdateCompany.Phone3 = entity[5].ToString();
            tblUpdateCompany.CityId = int.Parse(entity[6].ToString());
            tblUpdateCompany.StartGreetings = entity[7].ToString();
            tblUpdateCompany.EndGreetings = entity[8].ToString();
            tblUpdateCompany.Logo = entity[9].ToString();

            datacontext.tbl_COMPANY.Attach(tblUpdateCompany);
            var entry = datacontext.Entry(tblUpdateCompany);

            entry.Property(c => c.Name).IsModified = true;
            entry.Property(c => c.Address).IsModified = true;
            entry.Property(c => c.NearBy).IsModified = true;
            entry.Property(c => c.Phone1).IsModified = true;
            entry.Property(c => c.Phone2).IsModified = true;
            entry.Property(c => c.Phone3).IsModified = true;
            entry.Property(c => c.CityId).IsModified = true;
            entry.Property(c => c.StartGreetings).IsModified = true;
            entry.Property(c => c.EndGreetings).IsModified = true;
            entry.Property(c => c.Logo).IsModified = true;

            return datacontext.SaveChanges();
        }
        public object GetAllCompany()
        {
            return (from comp in datacontext.tbl_COMPANY
                    join c in datacontext.tbl_CITY on comp.CityId equals c.CityId
                    select new
                    {
                        comp.Name,
                        comp.Address,
                        comp.NearBy,
                        comp.Phone1,
                        comp.Phone2,
                        comp.Phone3,
                        comp.CityId,
                        c.City,
                        comp.StartGreetings,
                        comp.EndGreetings,
                        comp.Logo,
                        comp.CompanyId
                    })
                    .ToList()
                    .OrderBy(c => c.Name);
        }
        public object GetAllCompanyForDropDown()
        {
            return (from comp in datacontext.tbl_COMPANY
                    select new
                    {
                        comp.Name,
                        comp.CompanyId
                    })
                    .ToList()
                    .OrderBy(c => c.Name);
        }
        public object GetCompanyById(int companyId)
        {
            return datacontext.tbl_COMPANY
                .Where(c => c.CompanyId == companyId)
                .Select(c => c)
                .FirstOrDefault();
        }
    }
}