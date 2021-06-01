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
    public class peopleController : Controller
    {
        private sep6_3Entities db = new sep6_3Entities();

        // GET: people
        public async Task<ActionResult> Index()
        {
            return View(await db.people.ToListAsync());
        }

        // GET: people/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            people people = await db.people.FindAsync(id);
            if (people == null)
            {
                return HttpNotFound();
            }
            return View(people);
        }

        // GET: people/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: people/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,name,birth")] people people)
        {
            if (ModelState.IsValid)
            {
                db.people.Add(people);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(people);
        }

        // GET: people/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            people people = await db.people.FindAsync(id);
            if (people == null)
            {
                return HttpNotFound();
            }
            return View(people);
        }

        // POST: people/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name,birth")] people people)
        {
            if (ModelState.IsValid)
            {
                db.Entry(people).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(people);
        }

        // GET: people/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            people people = await db.people.FindAsync(id);
            if (people == null)
            {
                return HttpNotFound();
            }
            return View(people);
        }

        // POST: people/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            people people = await db.people.FindAsync(id);
            db.people.Remove(people);
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
