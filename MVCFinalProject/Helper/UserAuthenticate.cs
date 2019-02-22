﻿using System;
using Newtonsoft.Json;
using System.Collections;
using System.Web;
using HRMS.Service.UserService;

namespace HRMS.Utility.Helper
{
    public class UserAuthenticate
    {

        //Note Abbreviation: 
        // ES: Encrypted Session        
        // US: User Session

        /// <summary>
        /// Get the IsAuthenticated
        /// </summary>
        public static bool IsAuthenticated
        {

            get
            {
                bool check = false;
                try
                {
                    var jsonData = SecurityHelper.Decrypt(HttpContext.Current.Request.Cookies["ES"]["US"].ToString());
                    Hashtable decryptedData = JsonConvert.DeserializeObject<Hashtable>(jsonData);
                    //var User = GetUserDetailsFromCookie();
                    UserService _IUserService = new UserService();

                    var user = _IUserService.GetUsersDetailsById(Convert.ToInt64(decryptedData["LogId"]));
                    //if (user.AccountStatus != (int)Utility.Enums.AccountStatus.Active)
                    //{
                    //    check = false;
                    //}
                    //else
                        check = true;
                   

                }
                catch (Exception ex)
                {
                    check = false;
                }
                return check;

            }
        }

        /// <summary>
        /// Get the User Name
        /// </summary>
        public static string UserName
        {
            get
            {
                string value = string.Empty;
                if (HttpContext.Current.Request.Cookies["ES"] != null)
                {
                    var jsonData = SecurityHelper.Decrypt(HttpContext.Current.Request.Cookies["ES"]["US"].ToString());
                    Hashtable decryptedData = JsonConvert.DeserializeObject<Hashtable>(jsonData);
                    value = Convert.ToString(decryptedData["UserName"]);
                    decryptedData = null;
                }
                return value;

            }
        }


        /// <summary>
        /// Get the Remember me
        /// </summary>
        public static string RememberMe
        {
            get
            {
                string value = "false";
                if (HttpContext.Current.Request.Cookies["ES"] != null)
                {
                    var jsonData = SecurityHelper.Decrypt(HttpContext.Current.Request.Cookies["ES"]["US"].ToString());
                    Hashtable decryptedData = JsonConvert.DeserializeObject<Hashtable>(jsonData);
                    value = Convert.ToString(decryptedData["rememberme"]);
                    decryptedData = null;
                }
                return value;

            }
        }


        /// <summary>
        /// Get the User LogId
        /// </summary>

        public static string LogId
        {
            get
            {
                string value = string.Empty;
                if (HttpContext.Current.Request.Cookies["ES"] != null)
                {
                    var jsonData = SecurityHelper.Decrypt(HttpContext.Current.Request.Cookies["ES"]["US"].ToString());
                    Hashtable decryptedData = JsonConvert.DeserializeObject<Hashtable>(jsonData);
                    value = Convert.ToString(decryptedData["LogId"]);
                    decryptedData = null;
                }

                return value;


            }
        }

        /// <summary>
        /// Get the User Role
        /// </summary>
        public static string Role
        {
            get
            {
                string value = string.Empty;
                if (HttpContext.Current.Request.Cookies["ES"] != null)
                {
                    var jsonData = SecurityHelper.Decrypt(HttpContext.Current.Request.Cookies["ES"]["US"].ToString());
                    Hashtable decryptedData = JsonConvert.DeserializeObject<Hashtable>(jsonData);
                    value = Convert.ToString(decryptedData["Role"]);
                    decryptedData = null;
                }
                return value;

            }
        }


        /// <summary>
        /// Get the UserType
        /// </summary>

        public static string UserType
        {
            get
            {
                string value = string.Empty;
                if (HttpContext.Current.Request.Cookies["ES"] != null)
                {
                    var jsonData = SecurityHelper.Decrypt(HttpContext.Current.Request.Cookies["ES"]["US"].ToString());
                    Hashtable decryptedData = JsonConvert.DeserializeObject<Hashtable>(jsonData);
                    value = Convert.ToString(decryptedData["UserType"]);
                    decryptedData = null;
                }
                return value;


            }
        }



        /// <summary>
        /// To add the cookie 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="roleName"></param>
        /// <param name="logId"></param>
        /// <param name="userType"></param>
        /// <param name="rememberMe"></param>
        public static void AddLoginCookie(string userName, string roleName, string logId, string userType, string rememberMe)
        {
            Logout(System.Web.HttpContext.Current);


            Hashtable loggedData = new Hashtable();
            loggedData.Add("LogId", logId);
            loggedData.Add("UserName", userName);
            loggedData.Add("Role", roleName);
            loggedData.Add("UserType", userType);
            loggedData.Add("RememberMe", rememberMe);

            HttpCookie encryptedCookie = new HttpCookie("ES");
            encryptedCookie.Values.Add("US", SecurityHelper.Encrypt(Newtonsoft.Json.JsonConvert.SerializeObject(loggedData)));
            encryptedCookie.Expires = DateTime.Now.AddHours(24);

            HttpContext.Current.Response.Cookies.Add(encryptedCookie);
        }


        

        /// <summary>
        /// to Expire the user cookie
        /// </summary>
        /// <param name="context"></param>
        public static void Logout(HttpContext context)
        {
            if (context.Request.Cookies["ES"] != null)
            {
                context.Response.Cookies["ES"].Expires = DateTime.Now.AddDays(-1);
            }
            
        }

    }
}