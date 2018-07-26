using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ApiQuizz.Models;

namespace ApiQuizz.Controllers
{
    public class VideoLinksController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/VideoLinks
        //public IQueryable<VideoLink> GetVideoLinks()
        //{
        //    return db.VideoLinks;
        //}
        public async Task<IHttpActionResult> GetVideoLinks()
        {
            var videoLinks = await db.VideoLinks.ToListAsync();

            return Ok(videoLinks);
        }

        // GET: api/VideoLinks/5
        [ResponseType(typeof(VideoLink))]
        public async Task<IHttpActionResult> GetVideoLink(int id)
        {
            VideoLink videoLink = await db.VideoLinks.FindAsync(id);
            if (videoLink == null)
            {
                return NotFound();
            }

            return Ok(videoLink);
        }

        // PUT: api/VideoLinks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVideoLink(int id, VideoLink videoLink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != videoLink.VideoLinkId)
            {
                return BadRequest();
            }

            db.Entry(videoLink).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoLinkExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/VideoLinks
        [ResponseType(typeof(VideoLink))]
        public async Task<IHttpActionResult> PostVideoLink(VideoLink videoLink)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VideoLinks.Add(videoLink);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = videoLink.VideoLinkId }, videoLink);
        }

        // DELETE: api/VideoLinks/5
        [ResponseType(typeof(VideoLink))]
        public async Task<IHttpActionResult> DeleteVideoLink(int id)
        {
            VideoLink videoLink = await db.VideoLinks.FindAsync(id);
            if (videoLink == null)
            {
                return NotFound();
            }

            db.VideoLinks.Remove(videoLink);
            await db.SaveChangesAsync();

            return Ok(videoLink);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VideoLinkExists(int id)
        {
            return db.VideoLinks.Count(e => e.VideoLinkId == id) > 0;
        }
    }
}