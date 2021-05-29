using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SEP6;

namespace SEP6.Controllers
{
    public class directorsController : Controller
    {
        private SEP6_2Entities db = new SEP6_2Entities();

        // GET: directors
        public ActionResult Index()
        {
            return View(db.directors.ToList());
        }

        // GET: directors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            directors directors = db.directors.Find(id);
            if (directors == null)
            {
                return HttpNotFound();
            }
            return View(directors);
        }

        // GET: directors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: directors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "movie_id,person_id")] directors directors)
        {
            if (ModelState.IsValid)
            {
                db.directors.Add(directors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(directors);
        }

        // GET: directors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            directors directors = db.directors.Find(id);
            if (directors == null)
            {
                return HttpNotFound();
            }
            return View(directors);
        }

        // POST: directors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "movie_id,person_id")] directors directors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(directors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(directors);
        }

        // GET: directors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            directors directors = db.directors.Find(id);
            if (directors == null)
            {
                return HttpNotFound();
            }
            return View(directors);
        }

        // POST: directors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            directors directors = db.directors.Find(id);
            db.directors.Remove(directors);
            db.SaveChanges();
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
