using System;
using System.Collections;
using System.Linq;
using System.Text;
using nTierDAL.DAL;

namespace nTierBLL.BLL
{
    public class CityBLL
    {
        private static CityBLL instance;
        public static CityBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CityBLL();
                }
                return instance;
            }
        }
        public int AddCity(CityEntity entity)
        {
            ArrayList lstAddCity = new ArrayList();
            lstAddCity.Add(entity.CityName);
            lstAddCity.Add(entity.CountryId);
            return CityDAL.Instance.AddCity(lstAddCity);
        }
        public int UpdateCity(CityEntity entity)
        {
            ArrayList lstUpdateCity = new ArrayList();
            lstUpdateCity.Add(entity.CityName);
            lstUpdateCity.Add(entity.CountryId);
            return CityDAL.Instance.AddCity(lstUpdateCity);
        }
        public object GetAllCity()
        {
            return CityDAL.Instance.GetAllCity();
        }
        public object GetCityById(int cityId)
        {
            return CityDAL.Instance.GetCityById(cityId);
        }
    }
    public class CityEntity
    {
        public string CityName { get; set; }
        public int CountryId { get; set; }
    }
}
