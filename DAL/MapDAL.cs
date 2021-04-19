using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public static class MapDAL
    {
        private static OwDBContext db = new OwDBContext();

        public static bool InsertMap(Map map)
        {
            try
            {
                db.Map.Add(map);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public static bool DeleteMap(string mapId)
        {
            try
            {
                Map map=db.Map.Find(mapId);
                db.Map.Remove(map);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool UpdateMap(string oldMapId, Map map)
        {
            try
            {
                Map oldMap = db.Map.Find(oldMapId);
                oldMap.MapId = map.MapId;
                oldMap.MapName = map.MapName;
                oldMap.MapType = map.MapType;
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public static List<Map> SelectAllMap()
        {
            return db.Map.ToList();
        }

        public static Map SelectMapByMapId(string mapId)
        {
            IQueryable<Map> map = from m in db.Map where m.MapId == mapId select m;
            return map.ToList()[0];
        }

        public static List<Map> SelectMapByMapName(string mapName)
        {
            IQueryable<Map> map = from m in db.Map where m.MapName == mapName select m;
            return map.ToList();
        }

        public static List<Map> SelectMapByMapType(string mapType)
        {
            IQueryable<Map> map = from m in db.Map where m.MapType == mapType select m;
            return map.ToList();
        }

    } 
}
