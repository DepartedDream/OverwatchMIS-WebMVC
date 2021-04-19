using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public static class SkillDAL
    {
        private static OwDBContext db = new OwDBContext();

        public static bool InsertSkill (Skill skill)
        {
            try
            {
                db.Skill.Add(skill);
                db.SaveChanges();
                return true;
            }
            catch(Exception) 
            {
                return false;
            }
        }

        public static bool DeleteSkill (string skillId)
        {
            try
            {
                Skill skill=db.Skill.Find(skillId);
                db.Skill.Remove(skill);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool UpdateSkill(string oldSkillId, Skill skill)
        {
            try
            {
                Skill oldSkill=db.Skill.Find(oldSkillId);
                oldSkill.SkillId= skill.SkillId;
                oldSkill.SkillName = skill.SkillName;
                oldSkill.SkillDetail = skill.SkillDetail;
                oldSkill.HeroId = skill.HeroId;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Skill SelectSkillBySkillId(string skillId)
        {
            IQueryable<Skill> skill = from s in db.Skill where s.SkillId == skillId select s;
            return skill.ToList()[0];
        }

        public static List<Skill> SelectSkillBySkillName(string skillName)
        {
            IQueryable<Skill> skill = from s in db.Skill where s.SkillName == skillName select s;
            return skill.ToList();
        }

        public static List<Skill> SelectSkillByHeroId(string heroId)
        {
            IQueryable<Skill> skill = from s in db.Skill where s.HeroId == heroId select s;
            return skill.ToList();
        }

        public static List<Skill> SelectAllSkill() 
        {
            return db.Skill.ToList();
        }

    }
}
