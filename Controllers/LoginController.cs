using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataBase;

namespace CareCare.Controllers
{
    public class LoginController : Controller
    {

        private CareerCareDBEntities connection = new CareerCareDBEntities();
        // GET: Login

  
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult JobSeekerLogin(JobSeekerProfile logCredentials)
        {
            ViewBag.wrongCredentials = "You have typed an invaild Email or Password";
          //  ViewBag.wrong = 0;
            var isValid =connection.JobSeekerProfile.Where(data => data.JsEmail.Equals(logCredentials.JsEmail) &&  data.JsPassword.Equals(logCredentials.JsPassword)).FirstOrDefault();
            if (isValid != null)
            {
                Session["JsEmail"] = isValid.JsEmail;
                Session["JsPass"] = isValid.JsPassword;
                Session["JsId"] = isValid.JsId;
                return RedirectToAction("EmpIndex", "EmployeeHome");
            }

            ViewBag.Wrong = 1;
            return View("Error");
        }

        public ActionResult CompanyLogin(CompanyProfile logCredentials)
        {
            var CanLogin = connection.CompanyProfile.Where(data => data.CmpEmail.Equals(logCredentials.CmpEmail) && data.CmpPassword.Equals(logCredentials.CmpPassword)).FirstOrDefault();

            if (CanLogin !=null)
            {

                Session["CmpEmail"] = CanLogin.CmpEmail;
                Session["CmpPassword"] = CanLogin.CmpPassword;
                Session["CmpId"] = CanLogin.CmpId;

                

                return RedirectToAction("CmpIndex", "CompanyHome");
            }

            ViewBag.wrong = 1;
            return View("Error");
        }






    }


}