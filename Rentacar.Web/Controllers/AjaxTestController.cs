﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Rentacar.Web.Controllers
{
    public class AjaxTestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AjaxTestAction()
        {
            return PartialView("_AjaxTestView");
        }
    }
}