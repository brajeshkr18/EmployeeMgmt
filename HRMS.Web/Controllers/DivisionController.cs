using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Division;
using HRMS.Service.Master;
using HRMS.ViewModel;
using MVCFinalProject.Models;

namespace MVCFinalProject.Controllers
{
    public class DivisionController : Controller
    {
        //private MVC4ProjectEntities2 db = new MVC4ProjectEntities2();
        IDivisionService _IDivisionService = new DivisionService();
        IMasterService _IMasterService = new MasterService();
        // GET: /Division/
        public ActionResult Index()
        {
            var divisions = _IDivisionService.DivisionList();
            return View(divisions);
        }

        // GET: /Division/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DivisionViewModel division = _IDivisionService.Division(id);
            if (division == null)
            {
                return HttpNotFound();
            }
            return View(division);
        }

        // GET: /Division/Create
        public ActionResult Create()
        {
            ViewBag.CID = new SelectList(_IMasterService.Companies(), "CID", "CName");
            return View();
        }

        // POST: /Division/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DivisionViewModel division)
        {
            if (ModelState.IsValid)
            {
                _IDivisionService.SaveDivision(division);
                return RedirectToAction("Index");
            }

            ViewBag.CID = new SelectList(_IMasterService.Companies(), "CID", "CName", division.CID);
            return View(division);
        }

        // GET: /Division/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Division division = _IMasterService.Divisions(id);
            if (division == null)
            {
                return HttpNotFound();
            }
            ViewBag.CID = new SelectList(_IMasterService.Companies(), "CID", "CName", division.CID);
            return View(division);
        }

        // POST: /Division/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="DivID,Division_Name,Location,CID")] DivisionViewModel division)
        {
            if (ModelState.IsValid)
            {
                _IDivisionService.SaveDivision(division);
                return RedirectToAction("Index");
            }
            ViewBag.CID = new SelectList(_IMasterService.Companies(), "CID", "CName", division.CID);
            return View(division);
        }

        // GET: /Division/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DivisionViewModel division = _IDivisionService.Division(id);
            if (division == null)
            {
                return HttpNotFound();
            }
            return View(division);
        }

        // POST: /Division/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _IDivisionService.DeleteDivision(id);
            return RedirectToAction("Index");
        }

       
    }
}
