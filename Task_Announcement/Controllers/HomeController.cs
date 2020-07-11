using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Task_Announcement.Models;

namespace Task_Announcement.Controllers
{
    public class HomeController : Controller
    {
        AnnounceContext db;
        public HomeController(AnnounceContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Announces.ToList());
        }
    }
}
