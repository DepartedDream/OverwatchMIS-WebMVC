﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Main()
        {
            return View();
        }

        public ActionResult Introduction()
        {
            return View();
        }
    }
}