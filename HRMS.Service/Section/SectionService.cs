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
using HRMS.Model.Master;
using HRMSModel.ViewModel;
using System.Data.Entity;

namespace HRMS.Service.Section
{
    public class SectionService : ISectionService
    {
       
        private EmployeeMGMTEntities _Context = new EmployeeMGMTEntities();
        #region Public_Methods

        
        public List<SectionViewModel> SectionList()
        {
            List<SectionViewModel> pro = new List<SectionViewModel>();
            var Section = _Context.Sections.ToList();
            Mapper.Map(Section, pro);
            return pro;
        }
        public SectionViewModel Section(int? id)
        {
            SectionViewModel comp = new SectionViewModel();
            try
            {
                if (id != 0 && id != null)
                {
                    HRMS.Core.EntityModel.Section EntComp = _Context.Sections.Find(id);
                    Mapper.Map(EntComp, comp);
                }
            }
            catch (Exception EX)
            {

            }
            return comp;
        }
        public bool SaveSection(SectionViewModel dept)
        {
            HRMS.Core.EntityModel.Section tblSection = new HRMS.Core.EntityModel.Section();
            bool result = false;
            try
            {
                if (dept.SecID == 0)
                {
                    Mapper.Map(dept, tblSection);
                    _Context.Sections.Add(tblSection);
                    _Context.SaveChanges();
                    result = true;
                }
                else
                {
                    Mapper.Map(dept, tblSection);
                    _Context.Entry(tblSection).State = EntityState.Modified;
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
        public bool DeleteSection(int id)
        {
            try
            {

                HRMS.Core.EntityModel.Section sal = _Context.Sections.Find(id);
                _Context.Sections.Remove(sal); ;
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
