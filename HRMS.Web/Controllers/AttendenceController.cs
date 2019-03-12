using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Attendences;
using HRMS.Utility.Helper;
using HRMS.ViewModel;
using MVCFinalProject.Models;

namespace MVCFinalProject.Controllers
{
    [HandleError]
    [CustomAuthorize]
    public class AttendenceController : Controller
    {
        IAttendencesService _IAttendencesService = new AttendencesService();
        // GET: /Attendence/
        public ActionResult Index()
        { 
            var attendences = _IAttendencesService.AttendenceList();
            return View(attendences);
        }

        // GET: /Attendence/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null || id==0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HRMS.ViewModel.AttendenceViewModel attendence = _IAttendencesService.Attendence(id);
            if (attendence == null)
            {
                return HttpNotFound();
            }
            return View(attendence);
        }

        // GET: /Attendence/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Attendence attendence = db.Attendences.Find(id);
            var attendence = _IAttendencesService.Attendence(id);
            if (attendence == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpID = new SelectList(_IAttendencesService.EmployeeList(), "EmpID", "Name", attendence.EmpID);
            return View(attendence);
        }

        // POST: /Attendence/Edit/5
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AttendenceViewModel attendence)
        {
            
            if (ModelState.IsValid)
            {
                if (_IAttendencesService.SaveAttendence(attendence))
                    return RedirectToAction("Index");
                else
                    ModelState.AddModelError("", "Unable to save record ");
                ViewBag.Background = "alert alert-danger";
            }
            ViewBag.EmpID = new SelectList(_IAttendencesService.EmployeeList(), "EmpID", "Name", attendence.EmpID);
            return View(attendence);
        }

        // GET: /Attendence/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendenceViewModel attendence = _IAttendencesService.Attendence(id);
            if (attendence == null)
            {
                return HttpNotFound();
            }
            return View(attendence);
        }

        // POST: /Attendence/Delete/5
        [HttpPost, ActionName("Delete")]
      
        public ActionResult DeleteConfirmed(int id)
        {
            if(_IAttendencesService.DeleteAttendence(id))
            return RedirectToAction("Index");
            else
            return RedirectToAction("Index");
        }
        
    }
}
