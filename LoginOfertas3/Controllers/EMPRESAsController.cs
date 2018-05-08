using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LoginOfertas3;
using LoginOfertas3.Models;

namespace LoginOfertas3.Controllers
{
    public class EMPRESAsController : Controller
    {
        private OfertasEntities db = new OfertasEntities();

        // GET: EMPRESAs
        public ActionResult Index()
        {
            var eMPRESA = db.EMPRESA.Include(e => e.DIRECCION);
            return View(eMPRESA.ToList());
        }

        // GET: EMPRESAs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESA eMPRESA = db.EMPRESA.Find(id);
            if (eMPRESA == null)
            {
                return HttpNotFound();
            }
            return View(eMPRESA);
        }

        // GET: EMPRESAs/Create
        public ActionResult Create()
        {
            ViewBag.DIRECCION_DIR_ID = new SelectList(db.DIRECCION, "DIR_ID", "CALLE");
            return View();
        }

        // POST: EMPRESAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DIRECCION_DIR_ID,EMP_ID,EMP_NOMBRE,EMP_RUT")] EMPRESA eMPRESA)
        {
            if (ModelState.IsValid)
            {
                db.EMPRESA.Add(eMPRESA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DIRECCION_DIR_ID = new SelectList(db.DIRECCION, "DIR_ID", "CALLE", eMPRESA.DIRECCION_DIR_ID);
            return View(eMPRESA);
        }

        // GET: EMPRESAs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESA eMPRESA = db.EMPRESA.Find(id);
            if (eMPRESA == null)
            {
                return HttpNotFound();
            }
            ViewBag.DIRECCION_DIR_ID = new SelectList(db.DIRECCION, "DIR_ID", "CALLE", eMPRESA.DIRECCION_DIR_ID);
            return View(eMPRESA);
        }

        // POST: EMPRESAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DIRECCION_DIR_ID,EMP_ID,EMP_NOMBRE,EMP_RUT")] EMPRESA eMPRESA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPRESA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DIRECCION_DIR_ID = new SelectList(db.DIRECCION, "DIR_ID", "CALLE", eMPRESA.DIRECCION_DIR_ID);
            return View(eMPRESA);
        }

        // GET: EMPRESAs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPRESA eMPRESA = db.EMPRESA.Find(id);
            if (eMPRESA == null)
            {
                return HttpNotFound();
            }
            return View(eMPRESA);
        }

        // POST: EMPRESAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            EMPRESA eMPRESA = db.EMPRESA.Find(id);
            db.EMPRESA.Remove(eMPRESA);
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
