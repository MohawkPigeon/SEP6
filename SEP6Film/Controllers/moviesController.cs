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
using SEP6Film.Models;

namespace SEP6Film.Controllers
{
    public class moviesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: movies
        public async Task<ActionResult> Index()
        {
            var movies = db.movies.Include(m => m.ratings);
            return View(await movies.ToListAsync());
        }
        // GET: movies/Search?term=Dune
        public async Task<ActionResult> Search(string term)
        {
            var movies = db.movies.Where(m => m.title.Contains(term)).Include(m => m.ratings);
            return View(await movies.ToListAsync());
        }

        // GET: movies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            movies movies = await db.movies.FindAsync(id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            return View(movies);
        }

        // GET: movies/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.ratings, "movie_id", "movie_id");
            return View();
        }

        // POST: movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,title,year")] movies movies)
        {
            if (ModelState.IsValid)
            {
                db.movies.Add(movies);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id = new SelectList(db.ratings, "movie_id", "movie_id", movies.id);
            return View(movies);
        }

        // GET: movies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            movies movies = await db.movies.FindAsync(id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            ViewBag.id = new SelectList(db.ratings, "movie_id", "movie_id", movies.id);
            return View(movies);
        }

        // POST: movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,title,year")] movies movies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movies).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id = new SelectList(db.ratings, "movie_id", "movie_id", movies.id);
            return View(movies);
        }

        // GET: movies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            movies movies = await db.movies.FindAsync(id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            return View(movies);
        }

        // POST: movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            movies movies = await db.movies.FindAsync(id);
            db.movies.Remove(movies);
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
