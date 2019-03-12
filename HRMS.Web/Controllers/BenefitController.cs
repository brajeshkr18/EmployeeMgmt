using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Benefit;
using HRMS.ViewModel;
//using MVCFinalProject.Models;

namespace MVCFinalProject.Controllers
{
    public class BenefitController : Controller
    {
        IBenefitService _IBenefitService = new BenefitService();
        // GET: /Benefit/
        public ActionResult Index()
        {
            return View(_IBenefitService.BenefitList());
        }

        // GET: /Benefit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BenefitViewModel benefit = _IBenefitService.Benefit(id);
            if (benefit == null)
            {
                return HttpNotFound();
            }
            return View(benefit);
        }
        

        // GET: /Benefit/Edit/5
        public ActionResult Edit(int? id)
        {
            BenefitViewModel benefit = new BenefitViewModel();
            if (id != 0 && id!=null)
            {
                benefit = _IBenefitService.Benefit(id);
            }
           
            return View(benefit);
        }

        // POST: /Benefit/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BenefitViewModel benefit)
        {
            if (ModelState.IsValid)
            {
                _IBenefitService.SaveBenifit(benefit);
                return RedirectToAction("Index");
            }
            return View(benefit);
        }

        // GET: /Benefit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BenefitViewModel benefit = _IBenefitService.Benefit(id);
           // Benefit benefit = db.Benefits.Find(id);
            if (benefit == null)
            {
                return HttpNotFound();
            }
            return View(benefit);
        }

        // POST: /Benefit/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _IBenefitService.DeleteBenifit(id);
            return RedirectToAction("Index");
        }
        
    }
}
