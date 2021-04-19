using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;

namespace UI.Controllers
{
    public class HeroController : Controller
    {

        public ActionResult SelectHero()
        {
            ViewData["tankHeroHtml"]=ShowHeros("重装");
            ViewData["damageHeroHtml"] = ShowHeros("输出");
            ViewData["supportHeroHtml"] = ShowHeros("支援");
            string ShowHeros(string heroType) 
            {
                List<Hero> heros = SelectHeroBLL.SelectHeroByHeroType(heroType);
                string heroTypeDivHtml = "";
                for (int i = 0; i < heros.Count; i++) 
                {
                    string heroAHtml = string.Format("<a class=\"hero_a\" href =\"/Skill/ShowHero?hero_id={0}&hero_name={1}\"></a>", heros[i].HeroId, heros[i].HeroName);
                    string heroNameTextHtml = string.Format("<div class=\"hero_name_text\">{0}</div>", heros[i].HeroName);
                    string heroDivHtml = string.Format("<div class=\"hero\" style=\"background-image: url(/resource/SelectHero/{0}.png);\">{1}{2}</div>", heros[i].HeroId, heroAHtml, heroNameTextHtml);
                    heroTypeDivHtml = heroTypeDivHtml + heroDivHtml;
                }
                return heroTypeDivHtml;
            }
            return View();
        }

    }
}