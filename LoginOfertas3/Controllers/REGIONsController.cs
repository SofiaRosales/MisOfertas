using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LoginOfertas3.Models;

namespace LoginOfertas3.Controllers
{
    public class REGIONsController : Controller
    {
        private OfertasEntities db = new OfertasEntities();

        // GET: REGIONs
        public ActionResult Index()
        {
            return View(db.REGION.ToList());
        }

        // GET: REGIONs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGION rEGION = db.REGION.Find(id);
            if (rEGION == null)
            {
                return HttpNotFound();
            }
            return View(rEGION);
        }

        // GET: REGIONs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: REGIONs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "REG_ID,REG_NOMBRE")] REGION rEGION)
        {
            if (ModelState.IsValid)
            {
                db.REGION.Add(rEGION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rEGION);
        }

        // GET: REGIONs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGION rEGION = db.REGION.Find(id);
            if (rEGION == null)
            {
                return HttpNotFound();
            }
            return View(rEGION);
        }

        // POST: REGIONs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "REG_ID,REG_NOMBRE")] REGION rEGION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rEGION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rEGION);
        }

        // GET: REGIONs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REGION rEGION = db.REGION.Find(id);
            if (rEGION == null)
            {
                return HttpNotFound();
            }
            return View(rEGION);
        }

        // POST: REGIONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            REGION rEGION = db.REGION.Find(id);
            db.REGION.Remove(rEGION);
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
