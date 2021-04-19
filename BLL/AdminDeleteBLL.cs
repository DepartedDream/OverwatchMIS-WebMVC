using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public static class AdminDeleteBLL
    {
        public static string Delete(string id) 
        {
            if (id[0] == '1')
            {
                return Convert.ToString(HeroDAL.DeleteHero(id));
            }
            else if (id[0] == '3')
            {
                return Convert.ToString(SkillDAL.DeleteSkill(id));
            }
            else if (id[0] == '4')
            {
                return Convert.ToString(MapDAL.DeleteMap(id));
            }
            else 
            {
                return "false";
            }
        }

    }
}
