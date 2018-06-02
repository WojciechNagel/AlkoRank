using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    [Authorize]
    public class WhiskiesController : Controller
    {
        
        private AlkoholeDB db = new AlkoholeDB();

        [AllowAnonymous]
        public ActionResult Index(string searchString)
        {
            var whiskies = from w in db.Whisky
                select w;

            if (!String.IsNullOrEmpty(searchString))
            {
                whiskies = whiskies.Where(s => s.Nazwa.Contains(searchString));
            }

            return View(whiskies);
        }
        // GET: Whiskies
       /* public ActionResult Index()
        {
            return View(db.Whisky.ToList());
        }*/

        // GET: Whiskies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Whisky whisky = db.Whisky.Find(id);
            if (whisky == null)
            {
                return HttpNotFound();
            }
            return View(whisky);
        }

        // GET: Whiskies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Whiskies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WhiskyID,Nazwa,Kategoria,Oko,Nos,Język,Finisz,Ocena,Cena")] Whisky whisky)
        {
            if (ModelState.IsValid)
            {
                db.Whisky.Add(whisky);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(whisky);
        }

        // GET: Whiskies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Whisky whisky = db.Whisky.Find(id);
            if (whisky == null)
            {
                return HttpNotFound();
            }
            return View(whisky);
        }

        // POST: Whiskies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WhiskyID,Nazwa,Kategoria,Oko,Nos,Język,Finisz,Ocena,Cena")] Whisky whisky)
        {
            if (ModelState.IsValid)
            {
                db.Entry(whisky).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(whisky);
        }

        // GET: Whiskies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Whisky whisky = db.Whisky.Find(id);
            if (whisky == null)
            {
                return HttpNotFound();
            }
            return View(whisky);
        }

        // POST: Whiskies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Whisky whisky = db.Whisky.Find(id);
            db.Whisky.Remove(whisky);
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
