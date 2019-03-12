using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Master;
using HRMS.Service.Promotion;
using HRMS.ViewModel;
using MVCFinalProject.Models;

namespace MVCFinalProject.Controllers
{
    public class PromotionController : Controller
    {
        //private MVC4ProjectEntities2 db = new MVC4ProjectEntities2();
        IPromotionService _IPromotionService = new PromotionService();
        IMasterService _IMasterService = new MasterService();
        // GET: /Promotion/
        public ActionResult Index()
        {
            var promotions = _IPromotionService.PromotionList();
            return View(promotions);
        }

        // GET: /Promotion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromotionViewModel promotion = _IPromotionService.Promotion(id);
            if (promotion == null)
            {
                return HttpNotFound();
            }
            return View(promotion);
        }
        
        // GET: /Promotion/Edit/5
        public ActionResult Edit(int? id)
        {
            PromotionViewModel promotion =new  PromotionViewModel();
            if (id != null && id!=0)
            {
                promotion = _IPromotionService.Promotion(id);
            }
            if (promotion == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpID = new SelectList(_IMasterService.Employees(0), "EmpID", "Name", promotion.EmpID);
            return View(promotion);
        }

        // POST: /Promotion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PromotionViewModel promotion)
        {
            if (ModelState.IsValid)
            {
                _IPromotionService.SavePromotion(promotion);
                return RedirectToAction("Index");
            }
            ViewBag.EmpID = new SelectList(_IMasterService.Employees(0), "EmpID", "Name", promotion.EmpID);
            return View(promotion);
        }

        // GET: /Promotion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromotionViewModel promotion = _IPromotionService.Promotion(id);
            if (promotion == null)
            {
                return HttpNotFound();
            }
            return View(promotion);
        }

        // POST: /Promotion/Delete/5
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _IPromotionService.DeletePromotion(id);
            return RedirectToAction("Index");
        }
        
    }
}
