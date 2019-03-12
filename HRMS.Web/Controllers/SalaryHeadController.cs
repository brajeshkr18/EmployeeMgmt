using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.SalaryHead;
using HRMS.ViewModel;
using MVCFinalProject.Models;

namespace MVCFinalProject.Controllers
{
    public class SalaryHeadController : Controller
    {
        ISalaryHeadService _ISalaryHeadService = new SalaryHeadService();
        // GET: /SalaryHead/
        public ActionResult Index()
        {
            //return View(db.SalaryHeads.ToList());
            return View(_ISalaryHeadService.SalaryHeadList());
        }

        // GET: /SalaryHead/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryHeadViewModel salaryhead = _ISalaryHeadService.SalaryHead(id);
            if (salaryhead == null)
            {
                return HttpNotFound();
            }
            return View(salaryhead);
        }

        // GET: /SalaryHead/Edit/5
        public ActionResult Edit(int? id)
        {
            SalaryHeadViewModel salaryhead = new SalaryHeadViewModel();
            if (id != null && id!=0)
            {
                salaryhead = _ISalaryHeadService.SalaryHead(id);
            }
            return View(salaryhead);
        }

        // POST: /SalaryHead/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SalaryHeadViewModel salaryhead)
        {
            if (ModelState.IsValid)
            {
                _ISalaryHeadService.SaveSalaryHead(salaryhead);
                return RedirectToAction("Index");
            }
            return View(salaryhead);
        }

        // GET: /SalaryHead/Delete/5
        public ActionResult Delete(int? id)
        {
            SalaryHeadViewModel salaryhead = new SalaryHeadViewModel();
            if (id != null && id != 0)
            {
                salaryhead = _ISalaryHeadService.SalaryHead(id);
            }
            return View(salaryhead);
        }

        // POST: /SalaryHead/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _ISalaryHeadService.DeleteSalaryHead(id);
            return RedirectToAction("Index");
        }

    }
}
