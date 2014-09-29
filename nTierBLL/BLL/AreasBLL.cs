using System;
using System.Collections;
using System.Linq;
using System.Text;
using nTierDAL.DAL;

namespace nTierBLL.BLL
{
    public class AreasBLL
    {
        private static AreasBLL instance;
        public static AreasBLL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AreasBLL();
                }
                return instance;
            }
        }
        public int AddArea(AreaEntity entity)
        {
            ArrayList lstAddArea = new ArrayList();
            lstAddArea.Add(entity.CityId);
            lstAddArea.Add(entity.Area);
            return AreasDAL.Instance.AddArea(lstAddArea);
        }
        public int UpdateArea(AreaEntity entity)
        {
            ArrayList lstUpdateArea = new ArrayList();
            lstUpdateArea.Add(entity.CityId);
            lstUpdateArea.Add(entity.Area);
            return AreasDAL.Instance.UpdateArea(lstUpdateArea);
        }
        public object GetAllArea()
        {
            return AreasDAL.Instance.GetAllArea();
        }
        public object GetAllAreaForDropDown()
        {
            return AreasDAL.Instance.GetAllAreaForDropDown();
        }
        public object GetAreaById(int areaId)
        {
            return AreasDAL.Instance.GetAreaById(areaId);
        }
    }
    public class AreaEntity
    {
        public int AreaId { get; set; }
        public int CityId { get; set; }
        public string Area { get; set; }
    }
}
