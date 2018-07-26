using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Backend.Models;

namespace Backend.Controllers
{
    public class VideoLinksController : Controller
    {
        private DataContext db = new DataContext();

        // GET: VideoLinks
        public async Task<ActionResult> Index()
        {
            return View(await db.VideoLinks.ToListAsync());
        }

        // GET: VideoLinks/Details/5
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

        // GET: VideoLinks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VideoLinks/Create
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

        // GET: VideoLinks/Edit/5
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

        // POST: VideoLinks/Edit/5
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

        // GET: VideoLinks/Delete/5
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

        // POST: VideoLinks/Delete/5
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
