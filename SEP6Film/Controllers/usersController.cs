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
    public class usersController : Controller
    {
        private sep6_3Entities db = new sep6_3Entities();
        public ActionResult Index(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return View(db.movies.Where(x => x.id < 50000).ToList());
            }
            else 
            using (db)
            {
                var user = (from us in db.user
                            where string.Compare(email, us.email, StringComparison.OrdinalIgnoreCase) == 0
                            && string.Compare(password, us.password, StringComparison.OrdinalIgnoreCase) == 0
                            select us).Include(x => x.movies).FirstOrDefault();

                    HttpContext.Response.Cookies["username"].Value = user.id + string.Empty;

                    //return View(db.user.Where(x => x.movies == user.movies).ToList());
                    //return View(db.movies.Where(x => x.user..ToList());

                    //using (db)
                    //{
                    //    var user2 = db.user
                    //        .Include(u => u.movies)
                    //        .FirstOrDefaultAsync(p => p.id == 1);
                    //}

                    //return View(db.user.Include(x => x.movies).Where(x => x.movies == user.movies).ToList());
                    // var user_ = db.user.Include(x => x.movies);

                    return View(user.movies.ToList()); 
                   // return View(db.movies.Include(x => x.user).Where(x => x.id < 50000).ToList());
                }
        }

        // GET: users
        //public async Task<ActionResult> Index()
        //{
        //    return View(await db.user.ToListAsync());
        //}



        // GET: users/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = await db.user.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,email,password")] user user)
        {
            if (ModelState.IsValid)
            {
                db.user.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: users/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = await db.user.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,email,password")] user user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: users/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user user = await db.user.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            user user = await db.user.FindAsync(id);
            db.user.Remove(user);
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
