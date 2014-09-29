using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace nTierDAL.DAL
{
    public class CountryDAL
    {
        private FrontOfficeCRMContainer datacontext;
        private static CountryDAL instance;
        public static CountryDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CountryDAL();
                }
                return instance;
            }
        }
        public CountryDAL()
        {
            datacontext = new FrontOfficeCRMContainer();
        }
        public int AddCountry(ArrayList entity)
        {
            tbl_COUNTRY tblAddCountry = new tbl_COUNTRY();
            tblAddCountry.Country = entity[0].ToString();
            datacontext.tbl_COUNTRY.Add(tblAddCountry);
            return datacontext.SaveChanges();
        }
        public int UpdateCountry(ArrayList entity)
        {
            tbl_COUNTRY tblUpdateCountry = new tbl_COUNTRY();
            tblUpdateCountry.Country = entity[0].ToString();

            datacontext.tbl_COUNTRY.Attach(tblUpdateCountry);
            var entry = datacontext.Entry(tblUpdateCountry);
            entry.Property(c => c.Country).IsModified = true;
            return datacontext.SaveChanges();
        }
        public object GetCountryById(int countryId)
        {
            return datacontext.tbl_COUNTRY
                .Where(c => c.CountryId == countryId)
                .Select(c => new
                {
                    c.CountryId,
                    c.Country
                })
                .FirstOrDefault();
        }
    }
}