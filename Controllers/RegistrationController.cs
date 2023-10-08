using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using DataBase;

namespace CareCare.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration

        private CareerCareDBEntities connection = new CareerCareDBEntities();

        public static bool isValidEmail(string inputEmail)
        {

            // This Pattern is use to verify the email
            string strRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

            Regex rgx = new Regex(strRegex, RegexOptions.IgnoreCase);

            if (rgx.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }

        public static bool isValidMobileNumber(string  inputMobileNumber)
        {
            string strRegex = @"(^[0-9]{11}$)|(^\+[0-9]{2}\s+[0-9]
                {2}[0-9]{11}$)";

            
            Regex rgx = new Regex(strRegex);

         
            if (rgx.IsMatch(inputMobileNumber))
                return (true);
            else
                return (false);
                
                // The string must contain at least 1 lowercase alphabetical character
                // The string must contain at least 1 uppercase alphabetical character
                // The string must contain at least 1 numeric character
                //	The string must contain at least one special character, but we are escaping reserved RegEx characters to avoid conflict
                //	The string must be eight characters or longer
        }

        public static bool isPassStrong(string inputPass)
        {

            string strRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{5,})";
            Regex rgx = new Regex(strRegex);

            if(rgx.IsMatch(inputPass))
            {
                return  (true);
            }
            else
            {
                return (false);
            }

        }





        public ActionResult SignUp()
        {
            return View();
        }


        [HttpPost]
        public ActionResult JobSeekerReg( JobSeekerProfile jobSeeker)
        {
            // ViewBag.ErrorNum = 0;
            ViewBag.AlreadyRegistered = "This account already exists";
            ViewBag.EmailCondition = "please Enter a Valid Email";
            ViewBag.PassCondition = "Password must Contain 1 lowercase , 1 uppercase , 1 Number , 1 Special Character and must be in range 5 - 10";
            bool checkReg = connection.JobSeekerProfile.Any(data => data.JsEmail.Equals(jobSeeker.JsEmail));
            if (!checkReg)
            {
                bool EmailStatus = isValidEmail(jobSeeker.JsEmail);
                bool PassStatus = isPassStrong(jobSeeker.JsPassword);
                if (EmailStatus && PassStatus)
                {
                    if (ModelState.IsValid)
                    {
                        connection.JobSeekerProfile.Add(jobSeeker);
                        connection.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }

                   

                    return View("Error");

                }
                else
                {
                    ViewBag.ErrorNum = 1;
                    return View("ValidationError");
                }

            }
            else
            {
                ViewBag.ErrorNum = 2;

                return View("ValidationError");

            }
            
          //  int Tmpnumbr = jobSeeker.JsPhone;
          //  string numbr = Tmpnumbr.ToString();
           // bool NumStatus = isValidMobileNumber(numbr);
            

          

            //if (ModelState.IsValid)
            //{
            //    connection.JobSeekerProfile.Add(jobSeeker);
            //    connection.SaveChanges();
            //    return RedirectToAction("Index", "Home");
            //}
            //else
            //{
            //    return View("Error");

            //}




        }


        [HttpPost]
        public ActionResult CompanyReg(CompanyProfile company)
        {

           // ViewBag.ErrorNum = 0;
            ViewBag.AlreadyRegistered = "This account already exists";
            ViewBag.EmailCondition = "please Enter a Valid Email";
            ViewBag.PassCondition = "Password must Contain 1 lowercase , 1 uppercase , 1 Number , 1 Special Character and must be in range 5 - 10";
            bool checkReg = connection.CompanyProfile.Any(data => data.CmpEmail.Equals(company.CmpEmail));
            if(!checkReg)
            {
                bool EmailStatus = isValidEmail(company.CmpEmail);
                string numbr = company.CmpContact;
                numbr = numbr.ToString();
                bool NumStatus = isValidMobileNumber(numbr);
                bool PassStatus = isPassStrong(company.CmpPassword);

                if (EmailStatus && PassStatus)
                {
                    if (ModelState.IsValid)
                    {
                        //Session["CmpId"] = company.CmpId;
                        connection.CompanyProfile.Add(company);
                        connection.SaveChanges();
                        //return RedirectToAction("JobSeekerReg");
                        return RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        return View("Error");

                    }

                }
                else
                {
                    ViewBag.ErrorNum = 1;
                    return View("ValidationError");
                }

            }
            else
            {

                ViewBag.ErrorNum = 2;

                return View("ValidationError");

            }



            //if (ModelState.IsValid)
            //{
            //    //Session["CmpId"] = company.CmpId;
            //    connection.CompanyProfile.Add(company);
            //    connection.SaveChanges();
            //    //return RedirectToAction("JobSeekerReg");
            //    return RedirectToAction("Index", "Home");

            //}
            //else
            //{
            //    return View("Error");

            //}


            
        }









    }
}