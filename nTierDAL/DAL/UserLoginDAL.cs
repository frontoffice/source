using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;
using nTierDAL;

namespace nTierDAL.DAL
{
    public class UserLoginDAL
    {
        private FrontOfficeCRMContainer entity;
        public UserLoginDAL()
        {
            entity = new FrontOfficeCRMContainer();
        }
        public int GetUserLogin(string userName, string password)
        {
            int isAuthorized = entity.Users.Where(u => u.UserName == userName && u.Password == password).Count();
            if (isAuthorized > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}