﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WEBPROJECT.Controllers
{
    public class InstructionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}