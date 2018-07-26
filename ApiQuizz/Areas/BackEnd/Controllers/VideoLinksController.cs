using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ApiQuizz.Models;

namespace ApiQuizz.Areas.BackEnd.Controllers
{
    public class VideoLinksController : Controller
    {
        private DataContext db = new DataContext();

        // GET: BackEnd/VideoLinks
        public async Task<ActionResult> Index()
        {
            return View(await db.VideoLinks.ToListAsync());
        }

        // GET: BackEnd/VideoLinks/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoLink videoLink = await db.VideoLinks.FindAsync(id);
            if (videoLink == null)
            {
                return HttpNotFound();
            }
            return View(videoLink);
        }

        // GET: BackEnd/VideoLinks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackEnd/VideoLinks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "VideoLinkId,MinutesRequired,Description,Link")] VideoLink videoLink)
        {
            if (ModelState.IsValid)
            {
                db.VideoLinks.Add(videoLink);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(videoLink);
        }

        // GET: BackEnd/VideoLinks/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoLink videoLink = await db.VideoLinks.FindAsync(id);
            if (videoLink == null)
            {
                return HttpNotFound();
            }
            return View(videoLink);
        }

        // POST: BackEnd/VideoLinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "VideoLinkId,MinutesRequired,Description,Link")] VideoLink videoLink)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoLink).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(videoLink);
        }

        // GET: BackEnd/VideoLinks/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoLink videoLink = await db.VideoLinks.FindAsync(id);
            if (videoLink == null)
            {
                return HttpNotFound();
            }
            return View(videoLink);
        }

        // POST: BackEnd/VideoLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VideoLink videoLink = await db.VideoLinks.FindAsync(id);
            db.VideoLinks.Remove(videoLink);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
