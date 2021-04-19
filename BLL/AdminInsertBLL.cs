using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public static class AdminInsertBLL
    {
        public static string Insert(string text1, string text2, string text3, string text4)
        {
            if (text1[0] == '1')
            {
                Hero hero = new Hero(text1, text2, text3);
                return Convert.ToString(HeroDAL.InsertHero(hero));
            }
            else if (text1[0] == '3')
            {
                Skill skill = new Skill(text1, text2, text3,text4);
                return Convert.ToString(SkillDAL.InsertSkill(skill));
            }
            else if (text1[0] == '4')
            {
                Map map = new Map(text1, text2, text3);
                return Convert.ToString(MapDAL.InsertMap(map));
            }
            else
            {
                return "false";
            }
        }
    }
}
