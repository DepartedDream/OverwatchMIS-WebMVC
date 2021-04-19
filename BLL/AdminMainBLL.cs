using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public static class AdminMainBLL
    {
        public static List<Hero> GetHeroData() 
        {
            return HeroDAL.SelectAllHero();
        }

        public static List<Skill> GetSkillData() 
        {
            return SkillDAL.SelectAllSkill();
        }

        public static List<Map> GetMapData() 
        {
            return MapDAL.SelectAllMap(); ;
        }

    }
}
