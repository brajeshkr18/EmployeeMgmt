using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.EmployeeType;
using HRMS.ViewModel;
using MVCFinalProject.Models;

namespace MVCFinalProject.Controllers
{
    public class Employee_TypeController : Controller
    {
        IEmployeeTypeService _IEmployeeTypeService = new EmployeeTypeService();
        // GET: /Employee_Type/
        public ActionResult Index()
        {
            return View(_IEmployeeTypeService.EmployeeTypeList());
        }

        // GET: /Employee_Type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_TypeViewModel employee_type = _IEmployeeTypeService.EmployeeType(id);
            if (employee_type == null)
            {
                return HttpNotFound();
            }
            return View(employee_type);
        }


        // GET: /Employee_Type/Edit/5
        public ActionResult Edit(int? id)
        {
            Employee_TypeViewModel employee_type = new Employee_TypeViewModel();
            if (id != null && id!=0)
            {
                employee_type = _IEmployeeTypeService.EmployeeType(id);
            }
            return View(employee_type);
        }

        // POST: /Employee_Type/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee_TypeViewModel employee_type)
        {
            if (ModelState.IsValid)
            {
                _IEmployeeTypeService.SaveEmployeeType(employee_type);
                return RedirectToAction("Index");
            }
            return View(employee_type);
        }

        // GET: /Employee_Type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_TypeViewModel employee_type = _IEmployeeTypeService.EmployeeType(id);
            if (employee_type == null)
            {
                return HttpNotFound();
            }
            return View(employee_type);
        }

        // POST: /Employee_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _IEmployeeTypeService.DeleteEmployeeType(id);
            return RedirectToAction("Index");
        }
        
    }
}
