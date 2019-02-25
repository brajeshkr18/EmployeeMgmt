using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Master;
using HRMS.Service.SalaryHistory;
using HRMS.ViewModel;
using MVCFinalProject.Models;

namespace MVCFinalProject.Controllers
{
    public class SalaryHistoryController : Controller
    {
        private MVC4ProjectEntities2 db = new MVC4ProjectEntities2();
        ISalaryHistoryService _ISalaryHistoryService = new SalaryHistoryService();
        IMasterService _IMasterService = new MasterService();
        // GET: /SalaryHistory/
        public ActionResult Index()
        {
            var salaryhistories = _ISalaryHistoryService.SalaryHistoryList();
            return View(salaryhistories);
        }

        // GET: /SalaryHistory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryHistory salaryhistory = db.SalaryHistories.Find(id);
            if (salaryhistory == null)
            {
                return HttpNotFound();
            }
            return View(salaryhistory);
        }
        
        // GET: /SalaryHistory/Edit/5
        public ActionResult Edit(int? id)
        {
            SalaryHistoryViewModel salaryhistory = new SalaryHistoryViewModel();
            if (id != null && id!=0)
            {
                salaryhistory = _ISalaryHistoryService.SalaryHistory(id);
            }
           
            ViewBag.EmpID = new SelectList(_IMasterService.Employees(0), "EmpID", "Name", salaryhistory.EmpID);
            ViewBag.PromotionID = new SelectList(_IMasterService.Promotions(0), "PromotionID", "Promotion_type", salaryhistory.PromotionID);
            return View(salaryhistory);
        }

        // POST: /SalaryHistory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SalaryHistoryViewModel salaryhistory)
        {
            if (ModelState.IsValid)
            {
                _ISalaryHistoryService.SaveSalaryHistory(salaryhistory);
                return RedirectToAction("Index");
            }
            ViewBag.EmpID = new SelectList(db.Employees, "EmpID", "Name", salaryhistory.EmpID);
            ViewBag.PromotionID = new SelectList(db.Promotions, "PromotionID", "Promotion_type", salaryhistory.PromotionID);
            return View(salaryhistory);
        }

        // GET: /SalaryHistory/Delete/5
        public ActionResult Delete(int? id)
        {
            SalaryHistoryViewModel salaryhistory = _ISalaryHistoryService.SalaryHistory(id);
            return View(salaryhistory);
        }

        // POST: /SalaryHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _ISalaryHistoryService.DeleteSalaryHistory(id);
            return RedirectToAction("Index");
        }
        
    }
}
