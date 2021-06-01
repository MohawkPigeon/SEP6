using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SEP6Film;

namespace SEP6Film.Controllers
{
    public class ratingsController : Controller
    {
        private sep6_3Entities db = new sep6_3Entities();

        // GET: ratings
        public async Task<ActionResult> Index()
        {
            var ratings = db.ratings.Include(r => r.movies);
            return View(await ratings.ToListAsync());
        }

        // GET: ratings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ratings ratings = await db.ratings.FindAsync(id);
            if (ratings == null)
            {
                return HttpNotFound();
            }
            return View(ratings);
        }

        // GET: ratings/Create
        public ActionResult Create()
        {
            ViewBag.movie_id = new SelectList(db.movies, "id", "title");
            return View();
        }

        // POST: ratings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "movie_id,rating,votes")] ratings ratings)
        {
            if (ModelState.IsValid)
            {
                db.ratings.Add(ratings);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.movie_id = new SelectList(db.movies, "id", "title", ratings.movie_id);
            return View(ratings);
        }

        // GET: ratings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ratings ratings = await db.ratings.FindAsync(id);
            if (ratings == null)
            {
                return HttpNotFound();
            }
            ViewBag.movie_id = new SelectList(db.movies, "id", "title", ratings.movie_id);
            return View(ratings);
        }

        // POST: ratings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "movie_id,rating,votes")] ratings ratings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ratings).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.movie_id = new SelectList(db.movies, "id", "title", ratings.movie_id);
            return View(ratings);
        }

        // GET: ratings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ratings ratings = await db.ratings.FindAsync(id);
            if (ratings == null)
            {
                return HttpNotFound();
            }
            return View(ratings);
        }

        // POST: ratings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ratings ratings = await db.ratings.FindAsync(id);
            db.ratings.Remove(ratings);
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
