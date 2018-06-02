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
    public class WinaController : Controller
    {
        private AlkoholeDB db = new AlkoholeDB();



        [AllowAnonymous]
        public ActionResult Index(string searchString)
        {
            var wina = from w in db.Wina
                select w;

            if (!String.IsNullOrEmpty(searchString))
            {
                wina = wina.Where(s => s.Nazwa.Contains(searchString));
            }

            return View(wina);
        }
        // GET: Wina
        //public ActionResult Index()
        //{
         //   return View(db.Wina.ToList());
        //}

        // GET: Wina/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wino wino = db.Wina.Find(id);
            if (wino == null)
            {
                return HttpNotFound();
            }
            return View(wino);
        }

        // GET: Wina/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wina/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WinoId,Nazwa,RokProdukcji,Ocena,Cena")] Wino wino)
        {
            if (ModelState.IsValid)
            {
                db.Wina.Add(wino);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wino);
        }

        // GET: Wina/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wino wino = db.Wina.Find(id);
            if (wino == null)
            {
                return HttpNotFound();
            }
            return View(wino);
        }

        // POST: Wina/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WinoId,Nazwa,RokProdukcji,Ocena,Cena")] Wino wino)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wino).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wino);
        }

        // GET: Wina/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wino wino = db.Wina.Find(id);
            if (wino == null)
            {
                return HttpNotFound();
            }
            return View(wino);
        }

        // POST: Wina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wino wino = db.Wina.Find(id);
            db.Wina.Remove(wino);
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
