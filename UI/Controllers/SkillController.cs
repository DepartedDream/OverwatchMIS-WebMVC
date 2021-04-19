using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;

namespace UI.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        public ActionResult ShowHero()
        {
            string skillDivHtml = "";
            string heroId = Request.QueryString["hero_id"].ToString();
            string heroName = Request.QueryString["hero_name"].ToString();
            string skillIdAttr = string.Format("skill_id=\"{0}\"", heroId);
            string skillNameAttr = string.Format("skill_name=\"{0}\"", heroName);
            string skillDescribeAttr = " skill_detail=\"&nbsp\"";
            string skillHeroIdAttr = string.Format(" hero_id=\"{0}\"", heroId);
            string skillPicAttr = string.Format("style =\"background-image:url(resource/showhero/{0}/{0}.png)\"", heroId);
            string skillLogoHtml = string.Format("<div class=\"skill_logo\" {0} {1} {2} {3} {4}></div>", skillIdAttr, skillNameAttr, skillDescribeAttr, skillHeroIdAttr, skillPicAttr, skillPicAttr);
            skillDivHtml= skillDivHtml + skillLogoHtml;
            List<Skill> skills = ShowHeroBLL.SelectSkillByHeroId(heroId);
            for (int i = 0; i < skills.Count; i++)
            {
                skillIdAttr = string.Format("skill_id=\"{0}\"", skills[i].SkillId);
                skillNameAttr = string.Format("skill_name=\"{0}\"", skills[i].SkillName);
                skillDescribeAttr = string.Format("skill_detail=\"{0}\"", skills[i].SkillDetail);
                skillHeroIdAttr = string.Format("hero_id=\"{0}\"", skills[i].HeroId);
                skillPicAttr = string.Format("style =\"background-image:url(/resource/showhero/{0}/{1}.png)\"", skills[i].HeroId, skills[i].SkillId);
                skillLogoHtml = string.Format("<div class=\"skill_logo\" {0} {1} {2} {3} {4}></div>", skillIdAttr, skillNameAttr, skillDescribeAttr, skillHeroIdAttr, skillPicAttr);
                skillDivHtml= skillDivHtml + skillLogoHtml;
            }
            ViewData["skillDivHtml"] = skillDivHtml;
            return View();
        }
    }
}