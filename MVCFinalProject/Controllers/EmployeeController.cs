using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Employee;
using HRMS.Service.Master;
using HRMS.Utility.Helper;
using MVCFinalProject.Models;

namespace MVCFinalProject.Controllers
{
    [HandleError]
    [CustomAuthorize]
    public class EmployeeController : Controller
    {
        IEmployeeService _IEmployeeService = new EmployeeService();
        IMasterService _IMasterService = new MasterService();
        // GET: /Employee/
        public ActionResult Index()
        {
            var employees = _IEmployeeService.EmployeeList();
            return View(employees);
        }

        // GET: /Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HRMS.ViewModel.EmployeeViewModel employee = _IEmployeeService.Employee(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        
        // GET: /Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Background = "";
            HRMS.ViewModel.EmployeeViewModel employee = new HRMS.ViewModel.EmployeeViewModel();
            if (id != 0 && id!=null)
            {
                employee = _IEmployeeService.Employee(id);
            }
            ViewBag.Benefit_ID = new SelectList(_IMasterService.Benefits(0), "Benefit_ID", "Benefit_Type", employee.Benefit_ID);
            ViewBag.DID = new SelectList(_IMasterService.Departments(0), "DID", "DName", employee.DID);
            ViewBag.DesId = new SelectList(_IMasterService.Designations(0), "DesId", "DesName", employee.DesId);
            ViewBag.DivID = new SelectList(_IMasterService.Divisions(0), "DivID", "Division_Name", employee.DivID);
            ViewBag.EmployeeType_ID = new SelectList(_IMasterService.Employee_Type(0), "EmployeeType_ID", "Employee_Types", employee.EmployeeType_ID);
            ViewBag.GID = new SelectList(_IMasterService.Grades(0), "GID", "Grade_Name", employee.GID);
            ViewBag.SecID = new SelectList(_IMasterService.Sections(0), "SecID", "Section_Name", employee.SecID);
            return View(employee);
        }

        // POST: /Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HRMS.ViewModel.EmployeeViewModel employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_IEmployeeService.SaveEmployee(employee))
                        return RedirectToAction("Index");
                    else
                        ModelState.AddModelError("", "Unable to save record ");
                    ViewBag.Background = "alert alert-danger";
                }
                ViewBag.Benefit_ID = new SelectList(_IMasterService.Benefits(0), "Benefit_ID", "Benefit_Type", employee.Benefit_ID);
                ViewBag.DID = new SelectList(_IMasterService.Departments(0), "DID", "DName", employee.DID);
                ViewBag.DesId = new SelectList(_IMasterService.Designations(0), "DesId", "DesName", employee.DesId);
                ViewBag.DivID = new SelectList(_IMasterService.Divisions(0), "DivID", "Division_Name", employee.DivID);
                ViewBag.EmployeeType_ID = new SelectList(_IMasterService.Employee_Type(0), "EmployeeType_ID", "Employee_Types", employee.EmployeeType_ID);
                ViewBag.GID = new SelectList(_IMasterService.Grades(0), "GID", "Grade_Name", employee.GID);
                ViewBag.SecID = new SelectList(_IMasterService.Sections(0), "SecID", "Section_Name", employee.SecID);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                ViewBag.Background = "alert alert-danger";
            }
            
            return View(employee);
        }

        // GET: /Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HRMS.ViewModel.EmployeeViewModel employee = _IEmployeeService.Employee(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: /Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _IEmployeeService.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        
    }
}
