using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Designation;
using HRMS.ViewModel;
using MVCFinalProject.Models;

namespace MVCFinalProject.Controllers
{
    public class DesignationController : Controller
    {
        //private MVC4ProjectEntities2 db = new MVC4ProjectEntities2();
        IDesignationService _IDesignationService = new DesignationService();
        // GET: /Designation/
        public ActionResult Index()
        {
            return View(_IDesignationService.DesignationList());
        }

        // GET: /Designation/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignationViewModel designation = _IDesignationService.Designation(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }
        
        // GET: /Designation/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignationViewModel designation = _IDesignationService.Designation(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        // POST: /Designation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DesignationViewModel designation)
        {
            if (ModelState.IsValid)
            {
                _IDesignationService.SaveDesignation(designation);
                return RedirectToAction("Index");
            }
            return View(designation);
        }

        // GET: /Designation/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignationViewModel designation = _IDesignationService.Designation(id);
            if (designation == null)
            {
                return HttpNotFound();
            }
            return View(designation);
        }

        // POST: /Designation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _IDesignationService.DeleteDesignation(id);
            return RedirectToAction("Index");
        }

    }
}
