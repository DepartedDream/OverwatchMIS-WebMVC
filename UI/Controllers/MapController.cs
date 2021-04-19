using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;

namespace UI.Controllers
{
    public class MapController : Controller
    {
        // GET: Map
        public ActionResult ShowMap()
        {
            string mapDivHtml = "";
            List<Map> maps = ShowMapBLL.SelectAllMap();
            for (int i = 0; i < maps.Count(); i++)
            {
                string mapIdAttr = string.Format("map_id=\"{0}\"", maps[i].MapId);
                string mapTypeAttr = string.Format("map_type=\"{0}\"", maps[i].MapType);
                string mapPicAttr = string.Format("style =\"background-image:url(/resource/showmap/{0}.png)\"", maps[i].MapId);
                string mapNameHTML = string.Format("<div class=\"map_text\">{0}</div>", maps[i].MapName);
                string mapHTML = string.Format("<div class=\"map\" {0} {1} {2} >{3}</div>", mapIdAttr, mapTypeAttr, mapPicAttr, mapNameHTML);
                mapDivHtml = mapDivHtml + mapHTML;
            }
            ViewData["mapDivHtml"] = mapDivHtml;
            return View();
        }
    }
}