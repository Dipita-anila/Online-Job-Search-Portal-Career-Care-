using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataBase;

namespace CareCare.Controllers
{
    public class EmployeeHomeController : Controller
    {
        private CareerCareDBEntities connection = new CareerCareDBEntities();
        // GET: EmployeeHome

        public bool BadWordCheck(string Commnet)
        {

            string[] arr = { "F*ck", "F*ck you", "Shit", "Piss off", "Dick head", "Asshole", "Bastard", "Bitch", "sala", "kutta", "fuck", "Fuck", "bodmaish", "rubbish" };
           
            bool res = arr.AsQueryable().Contains(Commnet);
            if(res)
            {
                return true;
            }
            else
            {
                return false;
            }
          

            
        }
        public ActionResult EmpIndex(string Title, string location)
        {
            if (Session["JsEmail"] == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                string email = Session["JsEmail"].ToString();
                JobSeekerProfile profile = connection.JobSeekerProfile.Where(data => data.JsEmail.Equals(email)).FirstOrDefault();
                if (location != null)
                {
                    //Title = Title.ToString();
                    location = location.ToString();
                    List<JobPost> jobs = new List<JobPost>();
                    List<JobPost> FilterByKyword = new List<JobPost>();
                    List<CompanyProfile> cmprofile = new List<CompanyProfile>();
                    List<Blog> blogpost = new List<Blog>();
                    jobs = (from s in connection.JobPost
                            join sa in connection.CompanyProfile on s.CmpId equals sa.CmpId
                            select s).ToList();
                    FilterByKyword = (from s in connection.JobPost
                                      join sa in connection.CompanyProfile on s.CmpId equals sa.CmpId
                                      where s.JobLocation == location
                                      select s).ToList();
                    var blogsql = "SELECT TOP 2 * FROM Blog";
                    blogpost = connection.Blog.SqlQuery(blogsql).ToList();

                    dynamic Imx = new System.Dynamic.ExpandoObject();
                    Imx.filter1 = jobs;
                    Imx.filter2 = FilterByKyword;
                    Imx.filter3 = profile;
                    Imx.filter4 = blogpost;



                    List<JobPost> DesignCreativeJobs = new List<JobPost>();
                    List<JobPost> ConstructionJobs = new List<JobPost>();
                    List<JobPost> DesignDevelopmentJobs = new List<JobPost>();
                    List<JobPost> SalesMarketingJobs = new List<JobPost>();
                    List<JobPost> MobileApplicationJobs = new List<JobPost>();
                    List<JobPost> ContentWriterJobs = new List<JobPost>();
                    List<JobPost> InformationTechnologyJobs = new List<JobPost>();
                    List<JobPost> RealEstateJobs = new List<JobPost>();


                    DesignCreativeJobs = connection.JobPost.Where(jb => jb.JobTag.Equals("designcreative")).ToList();
                    ConstructionJobs = connection.JobPost.Where(jb => jb.JobTag.Equals("construction")).ToList();
                    DesignDevelopmentJobs = connection.JobPost.Where(jb => jb.JobTag.Equals("designdevelopment")).ToList();
                    SalesMarketingJobs = connection.JobPost.Where(jb => jb.JobTag.Equals("salesmarketing")).ToList();
                    MobileApplicationJobs = connection.JobPost.Where(jb => jb.JobTag.Equals("mobileapplication")).ToList();
                    ContentWriterJobs = connection.JobPost.Where(jb => jb.JobTag.Equals("contentwriter")).ToList();
                    InformationTechnologyJobs = connection.JobPost.Where(jb => jb.JobTag.Equals("informationtechnology")).ToList();
                    RealEstateJobs = connection.JobPost.Where(jb => jb.JobTag.Equals("realestate")).ToList();



                    ViewBag.Ndesigncreative = DesignCreativeJobs.Count;
                    ViewBag.Nconstruction = ConstructionJobs.Count;
                    ViewBag.Ndesigndevelopment = DesignDevelopmentJobs.Count;
                    ViewBag.Nsalesmarketing = SalesMarketingJobs.Count;
                    ViewBag.Nmobileapplication = MobileApplicationJobs.Count;
                    ViewBag.Ncontentwriter = ContentWriterJobs.Count;
                    ViewBag.Ninformationtechnology = InformationTechnologyJobs.Count;
                    ViewBag.Nrealestate = RealEstateJobs.Count;






                    return View(Imx);


                }
                else
                {

                    List<JobPost> jobs = new List<JobPost>();

                    List<CompanyProfile> cmprofile = new List<CompanyProfile>();
                    List<Blog> blogpost = new List<Blog>();
                    jobs = (from s in connection.JobPost
                            join sa in connection.CompanyProfile on s.CmpId equals sa.CmpId
                            select s).ToList();
                    var blogsql = "SELECT TOP 2 * FROM Blog";
                    blogpost = connection.Blog.SqlQuery(blogsql).ToList();


                    dynamic Imx = new System.Dynamic.ExpandoObject();
                    Imx.filter1 = jobs;
                    Imx.filter2 = null;
                    Imx.filter3= profile;
                    Imx.filter4 = blogpost;

                    List<JobPost> DesignCreativeJobs = new List<JobPost>();
                    List<JobPost> ConstructionJobs = new List<JobPost>();
                    List<JobPost> DesignDevelopmentJobs = new List<JobPost>();
                    List<JobPost> SalesMarketingJobs = new List<JobPost>();
                    List<JobPost> MobileApplicationJobs = new List<JobPost>();
                    List<JobPost> ContentWriterJobs = new List<JobPost>();
                    List<JobPost> InformationTechnologyJobs = new List<JobPost>();
                    List<JobPost> RealEstateJobs = new List<JobPost>();


                    DesignCreativeJobs = connection.JobPost.Where(jb => jb.JobTag.Equals("designcreative")).ToList();
                    ConstructionJobs = connection.JobPost.Where(jb => jb.JobTag.Equals("construction")).ToList();
                    DesignDevelopmentJobs = connection.JobPost.Where(jb => jb.JobTag.Equals("designdevelopment")).ToList();
                    SalesMarketingJobs = connection.JobPost.Where(jb => jb.JobTag.Equals("salesmarketing")).ToList();
                    MobileApplicationJobs = connection.JobPost.Where(jb => jb.JobTag.Equals("mobileapplication")).ToList();
                    ContentWriterJobs = connection.JobPost.Where(jb => jb.JobTag.Equals("contentwriter")).ToList();
                    InformationTechnologyJobs = connection.JobPost.Where(jb => jb.JobTag.Equals("informationtechnology")).ToList();
                    RealEstateJobs = connection.JobPost.Where(jb => jb.JobTag.Equals("realestate")).ToList();



                    ViewBag.Ndesigncreative = DesignCreativeJobs.Count;
                    ViewBag.Nconstruction = ConstructionJobs.Count;
                    ViewBag.Ndesigndevelopment = DesignDevelopmentJobs.Count;
                    ViewBag.Nsalesmarketing = SalesMarketingJobs.Count;
                    ViewBag.Nmobileapplication = MobileApplicationJobs.Count;
                    ViewBag.Ncontentwriter = ContentWriterJobs.Count;
                    ViewBag.Ninformationtechnology = InformationTechnologyJobs.Count;
                    ViewBag.Nrealestate = RealEstateJobs.Count;



                    return View(Imx);


                }


            }

        }

        public ActionResult EmpAbout()
        {
            if (Session["JsEmail"] == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                string email = Session["JsEmail"].ToString();
                JobSeekerProfile profile = connection.JobSeekerProfile.Where(data => data.JsEmail.Equals(email)).FirstOrDefault();



                return View(profile);
            }
            return View();
        }

        public ActionResult EmpFindJob(String Category, String JobType, String JobLocation, string Experience)
        {
            if (Session["JsEmail"] == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                string email = Session["JsEmail"].ToString();
                JobSeekerProfile profile = connection.JobSeekerProfile.Where(data => data.JsEmail.Equals(email)).FirstOrDefault();


                if (Category == null && JobType == null && JobLocation == null && Experience == null)
                {

                    List<JobPost> jobs = new List<JobPost>();
                    List<CompanyProfile> cmprofile = new List<CompanyProfile>();
                    jobs = (from s in connection.JobPost
                            join sa in connection.CompanyProfile on s.CmpId equals sa.CmpId
                            select s).ToList();
                    dynamic Imx = new System.Dynamic.ExpandoObject();
                    Imx.filter2 = jobs;
                    Imx.filter1 = profile;
                    ViewBag.ResultsCount = jobs.Count;

                    return View(Imx);

                }
                else if (Category != null || JobType != null || JobLocation != null || Experience != null)
                {

                    //Title = Title.ToString();


                    List<JobPost> FilterByCategory = new List<JobPost>();
                    List<CompanyProfile> cmprofile = new List<CompanyProfile>();
                    if (Category != null && JobType != null && JobLocation != null && Experience != null)
                    {

                        FilterByCategory = (from s in connection.JobPost
                                            join sa in connection.CompanyProfile on s.CmpId equals sa.CmpId
                                            where s.JobTag == Category && s.JobLocation == JobLocation && s.JobNature == JobType && s.JobExperience == Experience
                                            select s).ToList();

                        dynamic Imx = new System.Dynamic.ExpandoObject();
                        ViewBag.ResultsCount = FilterByCategory.Count;

                        Imx.filter2 = FilterByCategory;
                        Imx.filter1 = profile;


                        return View(Imx);

                    }
                    else
                    {

                        FilterByCategory = (from s in connection.JobPost
                                            join sa in connection.CompanyProfile on s.CmpId equals sa.CmpId
                                            where s.JobTag == Category || s.JobLocation == JobLocation || s.JobNature == JobType || s.JobExperience == Experience
                                            select s).ToList();

                        dynamic Imx = new System.Dynamic.ExpandoObject();
                        ViewBag.ResultsCount = FilterByCategory.Count;

                        Imx.filter2 = FilterByCategory;
                        Imx.filter1 = profile;


                        return View(Imx);


                    }




                }



            }

            return View();
        }

        [HttpGet]
        public ActionResult EmpJobDetails(int jobid)
        {

            if (Session["JsEmail"] == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                string email = Session["JsEmail"].ToString();
                JobSeekerProfile profile = connection.JobSeekerProfile.Where(data => data.JsEmail.Equals(email)).FirstOrDefault();

                List<JobPost> jobs = new List<JobPost>();

                List<CompanyProfile> cmprofile = new List<CompanyProfile>();
                jobs = (from s in connection.JobPost
                        join sa in connection.CompanyProfile on s.CmpId equals sa.CmpId where s.JobId ==  jobid
                        select s).ToList();


                dynamic Imx = new System.Dynamic.ExpandoObject();
                Imx.filter1 = jobs;
                Imx.filter3 = profile;

                return View(Imx);


            }


            


        }



        public ActionResult EmpShowInfo()
        {

            if (Session["JsEmail"] == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                string email = Session["JsEmail"].ToString();
                JobSeekerProfile profile = connection.JobSeekerProfile.Where(data => data.JsEmail.Equals(email)).FirstOrDefault();
                

                
                return View(profile);
            }


            return View();
        }

        public ActionResult EmpContact()
        {

            if (Session["JsEmail"] == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                string email = Session["JsEmail"].ToString();
                JobSeekerProfile profile = connection.JobSeekerProfile.Where(data => data.JsEmail.Equals(email)).FirstOrDefault();



                return View(profile);
            }



            return View();
        }



        public ActionResult EmpUpdateInfo()
        {
            if (Session["JsEmail"] == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                string email = Session["JsEmail"].ToString();
                JobSeekerProfile profile = connection.JobSeekerProfile.Where(data => data.JsEmail.Equals(email)).FirstOrDefault();



                return View(profile);
            }

            return View();
        }


        [HttpPost]
        public ActionResult EmpUpdateInfo(JobSeekerProfile jobSeeker)
        {

            //jobSeeker existingProfile = connection.jobSeeker.Where(temp => temp. == jobSeeker.passwordz).FirstOrDefault();
            JobSeekerProfile existingProfile = connection.JobSeekerProfile.Where(data => data.JsPassword.Equals(jobSeeker.JsPassword)).FirstOrDefault();
            if (existingProfile != null)
            {
                existingProfile.JsName = jobSeeker.JsName;
                existingProfile.JsDateOfBirth = jobSeeker.JsDateOfBirth;
                existingProfile.JsEmail = jobSeeker.JsEmail;
                existingProfile.JsPhone = jobSeeker.JsPhone;
                existingProfile.JsGender = jobSeeker.JsGender;
                existingProfile.JsAddress = jobSeeker.JsAddress;
                existingProfile.JsSkills = jobSeeker.JsSkills;
                existingProfile.JsCurrentPosition = jobSeeker.JsCurrentPosition;
                existingProfile.JsPassword = jobSeeker.JsNewPassword;


                //string filename = Path.GetFileNameWithoutExtension(jobSeeker.Cover.FileName);
                //string extension = Path.GetExtension(jobSeeker.Cover.FileName);
                //filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                //jobSeeker.imagepath = "~/ImgUploaded/" + filename;
                //filename = Path.Combine(Server.MapPath("~/ImgUploaded/"), filename);
                //jobSeeker.Cover.SaveAs(filename);
                //connection.JobSeeker_profile.Add(jobSeeker);



                string filename = Path.GetFileNameWithoutExtension(jobSeeker.Cover.FileName);
                string extension = Path.GetExtension(jobSeeker.Cover.FileName);
                filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                existingProfile.JsImagePath = "~/ImgUploaded/" + filename;
                filename = Path.Combine(Server.MapPath("~/ImgUploaded/"), filename);
                jobSeeker.Cover.SaveAs(filename);
              //  connection.JobSeekerProfile.Add(existingProfile);
                connection.SaveChanges();

                return RedirectToAction("EmpIndex", "EmployeeHome");

            }

            return View("Error");
        }



        public ActionResult EmpBlogList(string filterkey)
        {

            if (Session["JsEmail"] == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                string email = Session["JsEmail"].ToString();
                JobSeekerProfile profile = connection.JobSeekerProfile.Where(data => data.JsEmail.Equals(email)).FirstOrDefault();


                if (filterkey == null)
                {
                    List<Blog> blogpost = new List<Blog>();
                    var blogsql = "SELECT  * FROM Blog";
                    blogpost = connection.Blog.SqlQuery(blogsql).ToList();

                    dynamic Imx = new System.Dynamic.ExpandoObject();
                    Imx.filter1 = blogpost;
                    Imx.filter2 = profile;



                    List<Blog> InspirationBlog = new List<Blog>();
                    List<Blog> NoticeBlg = new List<Blog>();
                    List<Blog> AchievementBlog = new List<Blog>();
                    List<Blog> UpdatesBlog = new List<Blog>();
                    List<Blog> TravelNewsBlog = new List<Blog>();
                    List<Blog> ModernTechBlog = new List<Blog>();
                    List<Blog> ProductBlog = new List<Blog>();
                    List<Blog> HealthBlog = new List<Blog>();
                    List<Blog> NewsBlog = new List<Blog>();


                    NoticeBlg = connection.Blog.Where(blog => blog.BlogCatag.Equals("notice")).ToList();
                    InspirationBlog = connection.Blog.Where(blog => blog.BlogCatag.Equals("inspiration")).ToList();
                    AchievementBlog = connection.Blog.Where(blog => blog.BlogCatag.Equals("achievement")).ToList();
                    UpdatesBlog = connection.Blog.Where(blog => blog.BlogCatag.Equals("updates")).ToList();
                    TravelNewsBlog = connection.Blog.Where(blog => blog.BlogCatag.Equals("travelnews")).ToList();
                    ModernTechBlog = connection.Blog.Where(blog => blog.BlogCatag.Equals("moderntech")).ToList();
                    ProductBlog = connection.Blog.Where(blog => blog.BlogCatag.Equals("product")).ToList();
                    HealthBlog = connection.Blog.Where(blog => blog.BlogCatag.Equals("healthcare")).ToList();
                    NewsBlog = connection.Blog.Where(blog => blog.BlogCatag.Equals("news")).ToList();

                    ViewBag.Nnotice = NoticeBlg.Count;
                    ViewBag.Ninspiration = InspirationBlog.Count;
                    ViewBag.Nachievement = AchievementBlog.Count;
                    ViewBag.Nupdates = UpdatesBlog.Count;
                    ViewBag.Ntravelnews = TravelNewsBlog.Count;
                    ViewBag.Nmoderntech = ModernTechBlog.Count;
                    ViewBag.Nproduct = ProductBlog.Count;
                    ViewBag.Nhealthcare = HealthBlog.Count;
                    ViewBag.Nnews = NewsBlog.Count;



                    return View(Imx);

                }
                else
                {
                    filterkey = filterkey.ToString();
                    List<Blog> filteredBlog = new List<Blog>();
                    filteredBlog = connection.Blog.Where(data => data.BlogCatag.Equals(filterkey)).ToList();
                    dynamic Imx = new System.Dynamic.ExpandoObject();
                    Imx.filter1 = filteredBlog;
                    Imx.filter2 = profile;




                    List<Blog> InspirationBlog = new List<Blog>();
                    List<Blog> NoticeBlg = new List<Blog>();
                    List<Blog> AchievementBlog = new List<Blog>();
                    List<Blog> UpdatesBlog = new List<Blog>();
                    List<Blog> TravelNewsBlog = new List<Blog>();
                    List<Blog> ModernTechBlog = new List<Blog>();
                    List<Blog> ProductBlog = new List<Blog>();
                    List<Blog> HealthBlog = new List<Blog>();
                    List<Blog> NewsBlog = new List<Blog>();


                    NoticeBlg = connection.Blog.Where(blog => blog.BlogCatag.Equals("notice")).ToList();
                    InspirationBlog = connection.Blog.Where(blog => blog.BlogCatag.Equals("inspiration")).ToList();
                    AchievementBlog = connection.Blog.Where(blog => blog.BlogCatag.Equals("achievement")).ToList();
                    UpdatesBlog = connection.Blog.Where(blog => blog.BlogCatag.Equals("updates")).ToList();
                    TravelNewsBlog = connection.Blog.Where(blog => blog.BlogCatag.Equals("travelnews")).ToList();
                    ModernTechBlog = connection.Blog.Where(blog => blog.BlogCatag.Equals("moderntech")).ToList();
                    ProductBlog = connection.Blog.Where(blog => blog.BlogCatag.Equals("product")).ToList();
                    HealthBlog = connection.Blog.Where(blog => blog.BlogCatag.Equals("healthcare")).ToList();
                    NewsBlog = connection.Blog.Where(blog => blog.BlogCatag.Equals("news")).ToList();

                    ViewBag.Nnotice = NoticeBlg.Count;
                    ViewBag.Ninspiration = InspirationBlog.Count;
                    ViewBag.Nachievement = AchievementBlog.Count;
                    ViewBag.Nupdates = UpdatesBlog.Count;
                    ViewBag.Ntravelnews = TravelNewsBlog.Count;
                    ViewBag.Nmoderntech = ModernTechBlog.Count;
                    ViewBag.Nproduct = ProductBlog.Count;
                    ViewBag.Nhealthcare = HealthBlog.Count;
                    ViewBag.Nnews = NewsBlog.Count;



                    return View(Imx);


                }

                    

            }
        }

        public ActionResult EmpSingleBlogDetails(int blogid)
        {

            if (Session["JsEmail"] == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                string email = Session["JsEmail"].ToString();
                JobSeekerProfile profile = connection.JobSeekerProfile.Where(data => data.JsEmail.Equals(email)).FirstOrDefault();
                blogid = Convert.ToInt32(blogid);
                List<Blog> BlogDetails = new List<Blog>();
                BlogDetails = connection.Blog.Where(data => data.BlogId.Equals(blogid)).ToList();

                List<BlogComments> blogcomments = new List<BlogComments>();
                blogcomments = (from s in connection.BlogComments
                                join sa in connection.Blog on s.BlogId equals sa.BlogId
                                where s.BlogId == blogid
                                select s).ToList();

                ViewBag.CmntCnt = blogcomments.Count;


                dynamic Imx = new System.Dynamic.ExpandoObject();
                Imx.filter1 = BlogDetails;
                Imx.filter2 = profile;
                Imx.filter3 = blogcomments;


                return View(Imx);


            }

        }

        [HttpPost]
        public ActionResult EmpBlogComment(BlogComments Cmnt)
        {
            if(BadWordCheck(Cmnt.Comment))
            {

                return RedirectToAction("EmpIndex","EmployeeHome", new { Title="",location="" });
            }else
            {
                Cmnt.React = Convert.ToInt32(Cmnt.React);
                Cmnt.Comment = Cmnt.Comment.ToString();
                string email = Session["JsEmail"].ToString();
                JobSeekerProfile profile = connection.JobSeekerProfile.Where(data => data.JsEmail.Equals(email)).FirstOrDefault();
                Cmnt.CommenterName = profile.JsName;
                Cmnt.CommenterPic = profile.JsImagePath;
                connection.BlogComments.Add(Cmnt);
                connection.SaveChanges();
                return RedirectToAction("EmpSingleBlogDetails", "EmployeeHome", new {blogid=Cmnt.BlogId});

            }
                     
        }

        public ActionResult EmpNewsList()
        {


            return View();
        }

        [HttpPost]
        public ActionResult CVUpload(Applications CV1 )
        {
            ViewBag.CVError = "Please submit the correct File(pdf)";


            if (ModelState.IsValid)
            {
                string filename = Path.GetFileNameWithoutExtension(CV1.CVFile.FileName);
                string extension = Path.GetExtension(CV1.CVFile.FileName);
                if(extension!=".pdf")
                {
                    ViewBag.ErrorNum = 3;
                    return View("ValidationError");

                }
                else
                {
                    filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                    CV1.CV = "~/CV/" + filename;
                    filename = Path.Combine(Server.MapPath("~/CV/"), filename);
                    CV1.CVFile.SaveAs(filename);
                    //  connection.JobSeekerProfile.Add(existingProfile);


                    connection.Applications.Add(CV1);
                    connection.SaveChanges();
                    return RedirectToAction("EmpIndex", "EmployeeHome");

                }

            }else
            {
                return View("Error");

            }          
        }


        public ActionResult EmpAllAppliedJob()
        {


            if (Session["JsEmail"] == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                string email = Session["JsEmail"].ToString();
                JobSeekerProfile profile = connection.JobSeekerProfile.Where(data => data.JsEmail.Equals(email)).FirstOrDefault();
                int employeeId = profile.JsId;
                string x = profile.JsId.ToString();
                ViewBag.EmployeeId = employeeId;
                ViewBag.count = 1;

                List<JobPost> jobs = new List<JobPost>();
                List<Applications> applications = new List<Applications>();
                jobs = (from sa in connection.Applications
                        join s in connection.JobPost on sa.JobId equals s.JobId where sa.JsId==employeeId
                        select s).ToList();

        

                List<Applications> a = new List<Applications>();
                var query = "select * from Applications";
                a = connection.Applications.SqlQuery(query).ToList();


                dynamic Imx = new System.Dynamic.ExpandoObject();
                    Imx.filter1 = a;
                    Imx.filter2 = jobs;
                    Imx.filter3 = profile;

                    return View(Imx);


                }


            }


        



    }
}