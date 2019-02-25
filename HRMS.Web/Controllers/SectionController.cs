using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Section;
using HRMS.ViewModel;
using MVCFinalProject.Models;

namespace MVCFinalProject.Controllers
{
    public class SectionController : Controller
    {
        private MVC4ProjectEntities2 db = new MVC4ProjectEntities2();
        ISectionService _ISectionService = new SectionService();
        // GET: /Section/
        public ActionResult Index()
        {
            return View(_ISectionService.SectionList().ToList());
        }

        // GET: /Section/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionViewModel section = _ISectionService.Section(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

       
        // GET: /Section/Edit/5
        public ActionResult Edit(int? id)
        {
            SectionViewModel section = new SectionViewModel();
            if (id != null && id!=0)
            {
                section = _ISectionService.Section(id);
            }
            return View(section);
        }

        // POST: /Section/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( SectionViewModel section)
        {
            if (ModelState.IsValid)
            {
                _ISectionService.SaveSection(section);
                return RedirectToAction("Index");
            }
            return View(section);
        }

        // GET: /Section/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SectionViewModel section = _ISectionService.Section(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // POST: /Section/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _ISectionService.DeleteSection(id);
            return RedirectToAction("Index");
        }
        
    }
}
