using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nTierDAL.DAL;
using System.Web;
using System.Web.Security;

namespace nTierBLL.BLL
{
    public class CommonBLL
    {
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


        public object GetCountry()
        {
            return CommonDAL.Instance.GetAllCountry();
        }
        public object GetCity(int countryID)
        {
            return CommonDAL.Instance.GetCityByCountry(countryID);
        }
        public object GetAllUsersInformationFromDB()
        {
            return CommonDAL.Instance.GetAllUsersInformationFromDB();
        }
    }
}
