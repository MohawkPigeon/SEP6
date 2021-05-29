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
    public class starsController : Controller
    {
        private SEP6_2Entities db = new SEP6_2Entities();

        // GET: stars
        public ActionResult Index()
        {
            return View(db.stars.ToList());
        }

        // GET: stars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stars stars = db.stars.Find(id);
            if (stars == null)
            {
                return HttpNotFound();
            }
            return View(stars);
        }

        // GET: stars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: stars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "movie_id,person_id")] stars stars)
        {
            if (ModelState.IsValid)
            {
                db.stars.Add(stars);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stars);
        }

        // GET: stars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stars stars = db.stars.Find(id);
            if (stars == null)
            {
                return HttpNotFound();
            }
            return View(stars);
        }

        // POST: stars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "movie_id,person_id")] stars stars)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stars).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stars);
        }

        // GET: stars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stars stars = db.stars.Find(id);
            if (stars == null)
            {
                return HttpNotFound();
            }
            return View(stars);
        }

        // POST: stars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            stars stars = db.stars.Find(id);
            db.stars.Remove(stars);
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
