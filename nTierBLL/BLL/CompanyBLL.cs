using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nTierDAL;
using nTierDAL.DAL;
using System.Collections;

namespace nTierBLL.BLL
{
    public class CompanyBLL
    {
        private static CompanyBLL instance;
        public static CompanyBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CompanyBLL();
                }
                return instance;
            }
        }
        public int AddCompany(CompanyEntity company)
        {
            ArrayList lstAddCompany = new ArrayList();
            lstAddCompany.Add(company.Name);
            lstAddCompany.Add(company.Address);
            lstAddCompany.Add(company.NearBy);
            lstAddCompany.Add(company.Phone1);
            lstAddCompany.Add(company.Phone2);
            lstAddCompany.Add(company.Phone3);
            lstAddCompany.Add(company.CityId);
            lstAddCompany.Add(company.StartGreetings);
            lstAddCompany.Add(company.EndGreetings);
            lstAddCompany.Add(company.Logo);
            return CompanyDAL.Instance.AddCompany(lstAddCompany);
        }
        public int UpdateCompany(CompanyEntity company)
        {
            ArrayList lstUpdateCompany = new ArrayList();
            lstUpdateCompany.Add(company.Name);
            lstUpdateCompany.Add(company.Address);
            lstUpdateCompany.Add(company.NearBy);
            lstUpdateCompany.Add(company.Phone1);
            lstUpdateCompany.Add(company.Phone2);
            lstUpdateCompany.Add(company.Phone3);
            lstUpdateCompany.Add(company.CityId);
            lstUpdateCompany.Add(company.StartGreetings);
            lstUpdateCompany.Add(company.EndGreetings);
            lstUpdateCompany.Add(company.Logo);
            return CompanyDAL.Instance.UpdateCompany(lstUpdateCompany);
        }
        public object GetAllCompany()
        {
            return CompanyDAL.Instance.GetAllCompany();
        }
        public object GetAllCompanyForDropDown()
        {
            return CompanyDAL.Instance.GetAllCompanyForDropDown();
        }
        public object GetCompanyById(int companyId)
        {
            return CompanyDAL.Instance.GetCompanyById(companyId);
        }
    }
    public class CompanyEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string NearBy { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public int CityId { get; set; }
        public string StartGreetings { get; set; }
        public string EndGreetings { get; set; }
        public string Logo { get; set; }
    }
}
