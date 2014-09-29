using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace nTierDAL.DAL
{
    public class CityDAL
    {
        private FrontOfficeCRMContainer datacontext;
        private static CityDAL instance;
        public static CityDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CityDAL();
                }
                return instance;
            }
        }
        public CityDAL()
        {
            datacontext = new FrontOfficeCRMContainer();
        }
        public int AddCity(ArrayList entity)
        {
            tbl_CITY tblAddCity = new tbl_CITY();
            tblAddCity.City = entity[0].ToString();
            tblAddCity.CountryId = int.Parse(entity[1].ToString());
            datacontext.tbl_CITY.Add(tblAddCity);
            return datacontext.SaveChanges();
        }
        public int UpdateCity(ArrayList entity)
        {
            tbl_CITY tblUpdateCity = new tbl_CITY();
            tblUpdateCity.City = entity[0].ToString();
            tblUpdateCity.CountryId = int.Parse(entity[1].ToString());
            datacontext.tbl_CITY.Attach(tblUpdateCity);

            var entry = datacontext.Entry(tblUpdateCity);
            entry.Property(c => c.City).IsModified = true;
            entry.Property(c => c.CountryId).IsModified = true;

            return datacontext.SaveChanges();
        }
        public object GetAllCity()
        {
            return (from c in datacontext.tbl_CITY
                    join count in datacontext.tbl_COUNTRY on c.CountryId equals count.CountryId
                    select new
                    {
                        c.City,
                        c.CityId,
                        count.Country
                    })
                    .ToList()
                    .OrderBy(c => c.City);
        }
        public object GetCityById(int cityId)
        {
            return datacontext.tbl_CITY
                .Where(c => c.CityId == cityId)
                .Select(c => new
                {
                    c.CityId,
                    c.CountryId,
                    c.City
                })
                .FirstOrDefault();
        }
    }
}
