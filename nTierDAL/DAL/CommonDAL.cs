using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nTierDAL.DAL
{
    public class CommonDAL
    {
        private FrontOfficeCRMContainer datacontext;
        private static CommonDAL instance;
        public static CommonDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommonDAL();
                }
                return instance;
            }
        }
        public CommonDAL()
        {
            datacontext = new FrontOfficeCRMContainer();
        }
        public object GetAllCountry()
        {
            return datacontext.tbl_COUNTRY
                .Select(c => new
                {
                    c.CountryId,
                    c.Country
                })
                .OrderBy(c => c.Country)
                .ToList();
        }
        public object GetCityByCountry(int countryID)
        {
            return datacontext.tbl_CITY
                .Where(c => c.CountryId == countryID)
                .Select(c => new
                {
                    c.CityId,
                    c.City
                })
                .OrderBy(c => c.City)
                .ToList();
        }
        public object GetAllRolesFromDB()
        {
            return datacontext.aspnet_Roles
                .Select(r => new
                {
                    r.RoleId,
                    r.RoleName
                })
                .OrderBy(r => r.RoleName)
                .ToList();
        }
        public object GetAllUsersInformationFromDB()
        {
            return (from e in datacontext.aspnet_Employees
                    join u in datacontext.aspnet_Users on e.UserId equals u.UserId
                    join c in datacontext.tbl_CITY on e.CityId equals c.CityId
                    join cn in datacontext.tbl_COUNTRY on c.CountryId equals cn.CountryId
                    select new
                    {
                        e.FirstName,
                        e.LastName,
                        e.Gender,
                        e.BirthDate,
                        e.HireDate,
                        e.ResidenceAddress,
                        e.CityId,
                        c.City,
                        e.ResidenceTel,
                        e.OfficeTel,
                        e.MobileNo,
                        cn.CountryId,
                        cn.Country
                    })
                   .ToList()
                   .OrderBy(e => e.FirstName)
                   .ThenBy(e => e.LastName);
        }
    }
}
