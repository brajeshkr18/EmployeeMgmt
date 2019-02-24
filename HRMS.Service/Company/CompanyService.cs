using ExpressMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using HRMS.Core.EntityModel;
using HRMS.ViewModel.Model.Users;
using HRMS.ViewModel;
using HRMS.Model.Users;
using HRMSModel.ViewModel;
using System.Data.Entity;

namespace HRMS.Service.Company
{
    public class CompanyService : ICompanyService
    {
       
        private EmployeeMGMTEntities _Context = new EmployeeMGMTEntities();
        #region Public_Methods

        
        public dynamic CompanyList()
        {
            //List<CompanyViewModel> cvm = new List<CompanyViewModel>();
            var company = _Context.Companies.ToList();
            //Mapper.Map(company, cvm);
            return company;
        }
        public dynamic Company(int? id)
        {
            HRMS.Core.EntityModel.Company comp = new HRMS.Core.EntityModel.Company();
            try
            {
                if (id != 0 && id != null)
                {
                    comp = _Context.Companies.Find(id);
                  //  Mapper.Map(EntComp, comp);
                }
            }
            catch (Exception EX)
            {

            }
            return comp;
        }
        public bool SaveCompany(CompanyViewModel comp)
        {
            HRMS.Core.EntityModel.Company tblcompany = new HRMS.Core.EntityModel.Company();
            bool result = false;
            try
            {
                if (comp.CID == 0)
                {
                    Mapper.Map(comp, tblcompany);
                    _Context.Companies.Add(tblcompany);
                    _Context.SaveChanges();
                    result = true;
                }
                else
                {
                    Mapper.Map(comp, tblcompany);
                    _Context.Entry(tblcompany).State = EntityState.Modified;
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
        public bool DeleteCompany(int id)
        {
            try
            {
               
                HRMS.Core.EntityModel.Company comp = _Context.Companies.Find(id);
                _Context.Companies.Remove(comp); ;
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
