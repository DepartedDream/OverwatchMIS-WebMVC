using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public static class ShowMapBLL
    {
        public static  List<Map> SelectAllMap() 
        {
            return MapDAL.SelectAllMap();
        }
    }
}
