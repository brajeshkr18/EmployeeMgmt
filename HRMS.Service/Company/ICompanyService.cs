﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMS.Model.Users;
using HRMS.ViewModel;

namespace HRMS.Service.Company
{
    public interface ICompanyService
    {

        dynamic CompanyList();
        dynamic Company(int? id);
        bool SaveCompany(CompanyViewModel atten);
        bool DeleteCompany(int id);
    }
}
