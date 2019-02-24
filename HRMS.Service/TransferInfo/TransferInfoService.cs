using ExpressMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using HRMS.Core.EntityModel;
using HRMS.ViewModel.Model.Users;
using HRMS.ViewModel;
using HRMSModel.ViewModel;
using System.Data.Entity;

namespace HRMS.Service.TransferInfo
{
    public class TransferInfoService : ITransferInfoService
    {
       
        private EmployeeMGMTEntities _Context = new EmployeeMGMTEntities();
        #region Public_Methods

        
        public List<Transfer_InfoViewModel> TransferInfoList()
        {
            List<Transfer_InfoViewModel> transfer = new List<Transfer_InfoViewModel>();
            var tableTransferInfo = _Context.Transfer_Info.Include(t => t.Employee).ToList();
            Mapper.Map(tableTransferInfo, transfer);
            return transfer;
        }
        public Transfer_InfoViewModel TransferInfo(int? id)
        {
            Transfer_InfoViewModel comp = new Transfer_InfoViewModel();
            try
            {
                if (id != 0 && id != null)
                {
                    HRMS.Core.EntityModel.Transfer_Info EntComp = _Context.Transfer_Info.Find(id);
                    Mapper.Map(EntComp, comp);
                }
            }
            catch (Exception EX)
            {

            }
            return comp;
        }
        public bool SaveTransferInfo(Transfer_InfoViewModel dept)
        {
            HRMS.Core.EntityModel.Transfer_Info tblTransferInfo = new HRMS.Core.EntityModel.Transfer_Info();
            bool result = false;
            try
            {
                if (dept.TransferID == 0)
                {
                    Mapper.Map(dept, tblTransferInfo);
                    _Context.Transfer_Info.Add(tblTransferInfo);
                    _Context.SaveChanges();
                    result = true;
                }
                else
                {
                    Mapper.Map(dept, tblTransferInfo);
                    _Context.Entry(tblTransferInfo).State = EntityState.Modified;
                    _Context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception EX)
            {
                result = false;
            }
            return result;
        }
        public bool DeleteTransferInfo(int id)
        {
            try
            {

                HRMS.Core.EntityModel.Transfer_Info comp = _Context.Transfer_Info.Find(id);
                _Context.Transfer_Info.Remove(comp); ;
                _Context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        #endregion
    }
}
