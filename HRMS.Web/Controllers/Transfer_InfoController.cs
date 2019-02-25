using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.Attendences;
using HRMS.Service.TransferInfo;
using HRMS.ViewModel;
using MVCFinalProject.Models;

namespace MVCFinalProject.Controllers
{
    public class Transfer_InfoController : Controller
    {
        //private MVC4ProjectEntities2 db = new MVC4ProjectEntities2();
        IAttendencesService _IAttendencesService = new AttendencesService();
        ITransferInfoService _ITransfer_InfoService = new TransferInfoService();
        // GET: /Transfer_Info/
        public ActionResult Index()
        {
            var transfer_info = _ITransfer_InfoService.TransferInfoList();
            return View(transfer_info);
        }

        // GET: /Transfer_Info/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transfer_InfoViewModel transfer_info = _ITransfer_InfoService.TransferInfo(id);
            if (transfer_info == null)
            {
                return HttpNotFound();
            }
            return View(transfer_info);
        }
        
        // GET: /Transfer_Info/Edit/5
        public ActionResult Edit(int? id)
        {
            Transfer_InfoViewModel transfer_info = new Transfer_InfoViewModel();
            if (id != null && id!=0)
            {
                transfer_info = _ITransfer_InfoService.TransferInfo(id);
            }
            ViewBag.EmpID = new SelectList(_IAttendencesService.EmployeeList(), "EmpID", "Name", transfer_info.EmpID);
            return View(transfer_info);
        }

        // POST: /Transfer_Info/Edit/5
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Transfer_InfoViewModel transfer_info)
        {
            if (ModelState.IsValid)
            {
                _ITransfer_InfoService.SaveTransferInfo(transfer_info);
                return RedirectToAction("Index");
            }
            ViewBag.EmpID = new SelectList(_IAttendencesService.EmployeeList(), "EmpID", "Name", transfer_info.EmpID);
            return View(transfer_info);
        }

        // GET: /Transfer_Info/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transfer_InfoViewModel transfer_info = _ITransfer_InfoService.TransferInfo(id);
            if (transfer_info == null)
            {
                return HttpNotFound();
            }
            return View(transfer_info);
        }

        // POST: /Transfer_Info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _ITransfer_InfoService.DeleteTransferInfo(id);
            return RedirectToAction("Index");
        }
        
    }
}
