using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            var disp = db.Announces.ToList();
            return View(disp);
        }
        [HttpGet]
        public async Task<IActionResult> Filter(string title, string description, string data_added )
        {
            ViewData["title_an"] = title;
            ViewData["description"] = description;
            ViewData["data"] = data_added;

            var empquery = from x in db.Announces select x;

            if (!String.IsNullOrEmpty(title))
            {
                empquery = empquery.Where(x => x.Title.Contains(title));
            }
            if (!String.IsNullOrEmpty(description))
            {
                empquery = empquery.Where(x => x.Description.Contains(description));
            }
            if (!String.IsNullOrEmpty(data_added))
            {
                empquery = empquery.Where(x => x.data.Contains(data_added));
            }
            if(!String.IsNullOrEmpty(title) && !String.IsNullOrEmpty(description))
            {
                empquery = empquery.Where(x => x.Title.Contains(title) && x.Description.Contains(description));
                return View(await empquery.AsNoTracking().ToListAsync());
            }
            return View(await empquery.AsNoTracking().ToListAsync());
        }
        //Create announcement
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Announce user)
        {
            db.Announces.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //Edit announcement
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Announce user = await db.Announces.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Announce user)
        {
            db.Announces.Update(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //Delete announcement
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Announce user = await db.Announces.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Announce user = await db.Announces.FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                {
                    db.Announces.Remove(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
