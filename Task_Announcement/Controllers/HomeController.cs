using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Index()
        {
            return View(await db.Announces.ToListAsync());
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
