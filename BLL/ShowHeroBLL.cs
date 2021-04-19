using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public static class ShowHeroBLL
    {
        public static List<Skill> SelectSkillByHeroId(string heroId) 
        {
            return SkillDAL.SelectSkillByHeroId(heroId);
        }
    }
}
