using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace nTierDAL.DAL
{
    public class AreasDAL
    {
        private FrontOfficeCRMContainer datacontext;
        private static AreasDAL instance;
        public static AreasDAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AreasDAL();
                }
                return instance;
            }
        }
        public AreasDAL()
        {
            datacontext = new FrontOfficeCRMContainer();
        }
        public int AddArea(ArrayList entity)
        {
            tbl_AREAS tblAreas = new tbl_AREAS();
            tblAreas.CityId = int.Parse(entity[0].ToString());
            tblAreas.Area = entity[1].ToString();
            datacontext.tbl_AREAS.Add(tblAreas);
            return datacontext.SaveChanges();
        }
        public int UpdateArea(ArrayList entity)
        {
            tbl_AREAS tblAreas = new tbl_AREAS();
            tblAreas.CityId = int.Parse(entity[0].ToString());
            tblAreas.Area = entity[1].ToString();

            datacontext.tbl_AREAS.Attach(tblAreas);
            var entry = datacontext.Entry(tblAreas);
            entry.Property(a => a.CityId).IsModified = true;
            entry.Property(a => a.Area).IsModified = true;

            return datacontext.SaveChanges();
        }
        public object GetAllArea()
        {
            return (from a in datacontext.tbl_AREAS
                    join c in datacontext.tbl_CITY on a.CityId equals c.CityId
                    select new
                    {
                        a.AeraId,
                        a.CityId,
                        a.Area,
                        c.City
                    })
                   .ToList()
                   .OrderBy(a => a.Area);
        }
        public object GetAllAreaForDropDown()
        {
            return (from a in datacontext.tbl_AREAS
                    select new
                    {
                        a.AeraId,
                        a.Area,
                    })
                   .ToList()
                   .OrderBy(a => a.Area);
        }
        public object GetAreaById(int areaId)
        {
            return datacontext.tbl_AREAS
                .Where(a => a.AeraId == areaId)
                .Select(a => new
            {
                a.AeraId,
                a.CityId,
                a.Area
            })
            .FirstOrDefault();
        }
    }
}