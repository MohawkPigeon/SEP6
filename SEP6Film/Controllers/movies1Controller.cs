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
    public class movies1Controller : Controller
    {
        private sep6_3Entities db = new sep6_3Entities();

        //the first parameter is the option that we choose and the second parameter will use the textbox value  
        public ActionResult Index(string option, string search)
        {
            var searchRange = 65000;

            if (option == "Year")
            {
                int searchint=0;
                if (search != null)
                {
                    searchint = Convert.ToInt32(search);                 
                }
                return View(db.movies.Where(x => x.year == searchint || search == null).Where(x => x.id < searchRange).ToList());
            }
            else if (option == "Rating")
            {
                double searchdouble = 0;
                if (search != null) 
                {
                searchdouble = Convert.ToDouble(search);
                }
                return View(db.movies.Where(x => x.ratings.rating >= searchdouble || search == null).Where(x => x.id < searchRange).ToList());
            }
            else if (option == "Title")
            {
                return View(db.movies.Where(x => x.title.StartsWith(search) || search == null).Where(x => x.id < searchRange).ToList());
            }
            else if (option == "Votes")
            {
                int searchint = 0;
                if (search != null)
                {
                    searchint = Convert.ToInt32(search);                   
                }
                return View(db.movies.Where(x => x.ratings.votes >= searchint || search == null).Where(x => x.id < searchRange).ToList());
            }
            else if (option == "Star")
            {
                return View(db.movies.Where(x => x.stars.FirstOrDefault().name.StartsWith(search) || search == null).Where(x => x.id < searchRange).ToList());
            }
            else if (option == "Director")
            {
                return View(db.movies.Where(x => x.directors.FirstOrDefault().name.StartsWith(search) || search == null).Where(x => x.id < searchRange).ToList());
            }
            else
            {
                return View(db.movies.Where(x => x.id < searchRange).ToList());
            }
        }


        // GET: movies1/Details/5
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

        // GET: movies1/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(db.ratings, "movie_id", "movie_id");
            return View();
        }

        // POST: movies1/Create
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> addToFavorites([Bind(Include = "id,title,year")] movies movies)
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

        // GET: movies1/Edit/5
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

        // POST: movies1/Edit/5
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

        // GET: movies1/Delete/5
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

        // POST: movies1/Delete/5
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
