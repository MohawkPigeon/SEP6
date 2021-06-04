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
    public class chosenMoviesController : Controller
    {
        private sep6_3Entities db2 = new sep6_3Entities();

        [HttpGet]
        public async Task<ActionResult> Create(int ?id)
        {
                var user_id = int.Parse(HttpContext.Request.Cookies["username"].Value);

                var movie_ = db2.movies.Where(x => x.id == id).FirstOrDefault();

                var user = db2.user.Where(x => x.id == user_id).FirstOrDefault();
                user.movies.Add(movie_);
                db2.SaveChanges();
  

                return RedirectToAction("index", "movies1");
        }


        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int? id)
        {
            var user_id = int.Parse(HttpContext.Request.Cookies["username"].Value);

            var movie_ = db2.movies.Where(x => x.id == id).FirstOrDefault();

            var user = db2.user.Where(x => x.id == user_id).FirstOrDefault();
            user.movies.Remove(movie_);
            db2.SaveChanges();


            return RedirectToAction("index", "movies1");
        }

    }
}
