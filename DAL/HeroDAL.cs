using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public static class HeroDAL
    {
        private static OwDBContext db = new OwDBContext();

        public static bool InsertHero(Hero hero)
        {
            try
            {
                db.Hero.Add(hero);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool DeleteHero(string heroId)
        {
            try
            {
                Hero hero=db.Hero.Find(heroId);
                db.Hero.Remove(hero);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool UpdateHero(string oldHeroId, Hero hero)
        {
            try
            {
                Hero oldHero = db.Hero.Find(oldHeroId);
                oldHero.HeroId = hero.HeroId;
                oldHero.HeroName = hero.HeroName;
                oldHero.HeroType = hero.HeroType;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Hero SelectHeroByHeroId(string heroId)
        {
            IQueryable<Hero> hero = from s in db.Hero where s.HeroId == heroId select s;
            return hero.ToList()[0];
        }

        public static List<Hero> SelectHeroByHeroName(string heroName)
        {
            IQueryable<Hero> hero = from s in db.Hero where s.HeroName == heroName select s;
            return hero.ToList();
        }

        public static List<Hero> SelectHeroByHeroType(string heroType)
        {
            IQueryable<Hero> hero = from s in db.Hero where s.HeroType == heroType select s;
            return hero.ToList();
        }

        public static List<Hero> SelectAllHero()
        {
            return db.Hero.ToList();
        }

    }
}