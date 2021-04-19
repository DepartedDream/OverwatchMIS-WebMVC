using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;

namespace UI.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult AdminLogin()
        {
            if (Request.Form["userName"] != null)
            {
                if (Request.Form["password"] == AdminLoginBLL.GetAdminPwd(Request.Form["userName"]))
                {
                    HttpCookie cookie = new HttpCookie("Admin");
                    Response.Cookies.Add(cookie);
                    Response.Cookies["Admin"].Expires = DateTime.Now.AddMinutes(10);
                    Response.Redirect("/Admin/AdminMain");
                }
                else
                {
                    Response.Write("<script>{alert(\"账号或密码错误\")}</script>");
                }
            }
            return View();
        }

        public ActionResult AdminMain()
        {
            if (Request.Cookies["Admin"] != null)
            {
                if (Request.QueryString["tableType"] == "英雄" || Request.QueryString["tableType"] == null)
                {
                    string tableHtml = "";
                    List<Hero> heros = AdminMainBLL.GetHeroData();
                    string trHead = "<tr><td>英雄id</td><td>英雄名称</td><td>英雄类别</td><td>操作</td></tr>";
                    tableHtml = tableHtml + trHead;
                    foreach (Hero hero in heros) 
                    {
                        string editInputHtml = "<input type=\"button\" class=\"edit_input\" value=\"编辑\">";
                        string deleteInputHtml = "<input type =\"button\" class=\"delete_input\" value=\"删除\">";
                        string trBody = $"<tr><td>{hero.HeroId}</td><td>{hero.HeroName}</td><td>{hero.HeroType}</td><td>{editInputHtml}{deleteInputHtml}</td></tr>";
                        tableHtml = tableHtml + trBody;
                    }
                    string textInputHtml ="<input type =\"text\" spellcheck=\"false\" >";
                    string buttonInputHtml = "<input type =\"button\" id=\"insert_input\" value=\"添加\">";
                    string trBottom = $"<tr><td>{textInputHtml}</td><td>{textInputHtml}</td><td>{textInputHtml}</td><td>{buttonInputHtml}</td></tr>";
                    tableHtml = tableHtml+trBottom;
                    ViewData["tableHtml"] = tableHtml;
                }
                else if (Request.QueryString["tableType"] == "技能")
                {
                    string tableHtml = "";
                    List<Skill> skills = AdminMainBLL.GetSkillData();
                    string trHead = "<tr><td>技能id</td><td>技能名称</td><td>技能描述</td><td>英雄id</td><td>操作</td></tr>";
                    tableHtml = tableHtml + trHead;
                    foreach (Skill skill in skills)
                    {
                        string editInputHtml = "<input type=\"button\" class=\"edit_input\" value=\"编辑\">";
                        string deleteInputHtml = "<input type =\"button\" class=\"delete_input\" value=\"删除\">";
                        string trBody = $"<tr><td>{skill.SkillId}</td><td>{skill.SkillName}</td><td>{skill.SkillDetail}</td><td>{skill.HeroId}</td><td>{editInputHtml}{deleteInputHtml}</td></tr>";
                        tableHtml = tableHtml + trBody;
                    }
                    string textInputHtml = "<input type =\"text\" spellcheck=\"false\" >";
                    string buttonInputHtml = "<input type =\"button\" id=\"insert_input\" value=\"添加\">";
                    string trBottom = $"<tr><td>{textInputHtml}</td><td>{textInputHtml}</td><td>{textInputHtml}</td><td>{textInputHtml}</td><td>{buttonInputHtml}</td></tr>";
                    tableHtml = tableHtml + trBottom;
                    ViewData["tableHtml"] = tableHtml;
                }
                else if (Request.QueryString["tableType"] == "地图")
                {
                    string tableHtml = "";
                    List<Map> maps = AdminMainBLL.GetMapData();
                    string trHead = "<tr><td>地图id</td><td>地图名称</td><td>地图类别</td><td>操作</td></tr>";
                    tableHtml = tableHtml + trHead;
                    foreach (Map map in maps)
                    {
                        string editInputHtml = "<input type=\"button\" class=\"edit_input\" value=\"编辑\">";
                        string deleteInputHtml = "<input type =\"button\" class=\"delete_input\" value=\"删除\">";
                        string trBody = $"<tr><td>{map.MapId}</td><td>{map.MapName}</td><td>{map.MapType}</td><td>{editInputHtml}{deleteInputHtml}</td></tr>";
                        tableHtml = tableHtml + trBody;
                    }
                    string textInputHtml = "<input type =\"text\" spellcheck=\"false\" >";
                    string buttonInputHtml = "<input type =\"button\" id=\"insert_input\" value=\"添加\">";
                    string trBottom = $"<tr><td>{textInputHtml}</td><td>{textInputHtml}</td><td>{textInputHtml}</td><td>{buttonInputHtml}</td></tr>";
                    tableHtml = tableHtml + trBottom;
                    ViewData["tableHtml"] = tableHtml;
                }
            }
            else
            {
                Response.Redirect("/Main/Main");
            }
            return View();
        }

        public void AdminInsert()
        {
            if (Request.Cookies["Admin"] != null)
            {
                string tableType = Request.QueryString["tableType"];
                string text1 = Request["text1"];
                string text2 = Request["text2"];
                string text3 = Request["text3"];
                string text4 = Request["text4"];
                string status = AdminInsertBLL.Insert(text1, text2, text3, text4);
                Response.Redirect($"/Admin/AdminMain?tableType={tableType}&status={status}");
            }
            else
            {
                Response.Redirect("/Main/Main");
            }
        }

        public void AdminUpdate()
        {
            if (Request.Cookies["Admin"] != null)
            {
                string oldId =Request["oldId"];
                string text1 =Request["text1"];
                string text2 =Request["text2"];
                string text3 =Request["text3"];
                string text4 =Request["text4"];
                string status = AdminUpdateBLL.Update(oldId, text1, text2, text3, text4);
                string tableType = Request.QueryString["tableType"];
                Response.Redirect($"/Admin/AdminMain?tableType={tableType}&status={status}");
            }
            else
            {
                Response.Redirect("/Main/Main");
            }
        }

        public void AdminDelete()
        {
            if (Request.Cookies["Admin"] != null)
            {
                string text1 = Request.QueryString["text1"];
                string status = AdminDeleteBLL.Delete(text1);
                string tableType = Request.QueryString["tableType"];
                Response.Redirect($"/Admin/AdminMain?tableType={tableType}&status={status}");
            }
            else
            {
                Response.Redirect("/Main/Main");
            }
        }

    }
}