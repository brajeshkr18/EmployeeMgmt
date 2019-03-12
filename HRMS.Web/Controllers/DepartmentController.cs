using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Department;
using HRMS.ViewModel;
using MVCFinalProject.Models;

namespace MVCFinalProject.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentService _IDepartMentService = new DepartmentService();
        // GET: /Department/
        public ActionResult Index()
        {
            return View(_IDepartMentService.DepartmentList());
        }

        // GET: /Department/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentViewModel department = _IDepartMentService.Department(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }
        
        // GET: /Department/Edit/5
        public ActionResult Edit(int? id)
        {
            DepartmentViewModel department = new DepartmentViewModel();
            if (id != null && id!=0)
            {
                department = _IDepartMentService.Department(id);
            }
            
            return View(department);
        }

        // POST: /Department/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DID,DName")] DepartmentViewModel department)
        {
            if (ModelState.IsValid)
            {
                _IDepartMentService.SaveDepartment(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: /Department/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentViewModel department = _IDepartMentService.Department(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: /Department/Delete/5
        [HttpPost, ActionName("Delete")]
       
        public ActionResult DeleteConfirmed(int id)
        {
            _IDepartMentService.DeleteDepartment(id);
            return RedirectToAction("Index");
        }
        
    }
}
