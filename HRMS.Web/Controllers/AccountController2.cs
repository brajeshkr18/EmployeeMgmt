﻿using HRMS.Model.Master;
using HRMS.Service.UserService;
using HRMS.Utility.Helper;
using HRMS.ViewModel;
using HRMS.ViewModel.Model.Users;
using HRMSModel.ViewModel;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HRMS.Service.User;

namespace MVCFinalProject.Controllers
{
    //[HandleError]
    public class AccountController2 : Controller
    {

        IUserService _IUserService = new UserService();

        public AccountController2()
        {
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (UserAuthenticate.IsAuthenticated)
            {
                System.Web.HttpContext.Current.Request.Cookies["ES"].Expires = DateTime.Now.AddHours(24);
               
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
            //if (TempData["result"] != null)
            //{
            //    var myJsonResult = TempData["result"] as MyJsonResult;
            //    if (myJsonResult.data != null)
            //        return View(new LoginViewModel { Email = myJsonResult.data.ToString() });
            //}
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.PasswordHash = SecurityHelper.CreatePasswordHash(model.Password, "");

                    UserViewModel authenticatedUser = null;
                    authenticatedUser = _IUserService.LoginAuthentication(model);

                    if (authenticatedUser != null)
                    {
                        string rememberme = (model.RememberMe) ? "true" : "false";
                        UserAuthenticate.AddLoginCookie(authenticatedUser.FirstName + " " + authenticatedUser.LastName, authenticatedUser.UserTypeCode, authenticatedUser.Id.ToString(),
                                     authenticatedUser.UserTypeName, rememberme);
                        return RedirectToAction("Index", "Admin");

                    }
                    else
                    {
                        ModelState.AddModelError("", "User Not Authenticated ");
                        // ViewBag.ErrorMsg = "Please check your username and password! ";
                    }
                }
                catch (CustomException customException)
                {
                    ModelState.AddModelError("", customException.Message);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Invalid login attempt");
                }

            }
            return View(model);
        }
        
        public ActionResult LogOff()
        {
            TempData.Keep("result");

            //if (UserAuthenticate.IsAuthenticated)
            //    _userService.UserLogOff(UserAuthenticate.LogId);
            UserAuthenticate.Logout(System.Web.HttpContext.Current);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Unauthorized()
        {
            UserAuthenticate.Logout(System.Web.HttpContext.Current);
            return View();
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

       
    }
}