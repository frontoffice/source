using System;
using System.Collections;
using System.Linq;
using System.Text;
using nTierDAL.DAL;

namespace nTierBLL.BLL
{
    public class CountryBLL
    {
        private static CountryBLL instance;
        public static CountryBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CountryBLL();
                }
                return instance;
            }
        }
        public int AddCountry(CountryEntity entity)
        {
            ArrayList lstAddCountry = new ArrayList();
            lstAddCountry.Add(entity.Country);
            return CountryDAL.Instance.AddCountry(lstAddCountry);
        }
        public int UpdateCountry(CountryEntity entity)
        {
            ArrayList lstUpdateCountry = new ArrayList();
            lstUpdateCountry.Add(entity.Country);
            return CountryDAL.Instance.AddCountry(lstUpdateCountry);
        }
        public object GetCountryById(int countryId)
        {
            return CountryDAL.Instance.GetCountryById(countryId);
        }
    }
    public class CountryEntity
    {
        public int CountryId { get; set; }
        public string Country { get; set; }
    }
}
