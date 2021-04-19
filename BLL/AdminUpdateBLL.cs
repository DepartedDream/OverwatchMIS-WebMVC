using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public static class AdminUpdateBLL
    {
        public static string Update(string oldId, string text1, string text2, string text3, string text4) 
        {
            if (oldId[0] == '1')
            {
                Hero hero = new Hero(text1, text2, text3);
                return Convert.ToString(HeroDAL.UpdateHero(oldId, hero));
            }
            else if (oldId[0] == '3')
            {
                Skill skill = new Skill(text1, text2, text3,text4);
                return Convert.ToString(SkillDAL.UpdateSkill(oldId, skill));
            }
            else if (oldId[0] == '4')
            {
                Map map = new Map(text1, text2, text3);
                return Convert.ToString(MapDAL.UpdateMap(oldId, map));
            }
            else
            {
                return "false";
            }
        }

    }
}
