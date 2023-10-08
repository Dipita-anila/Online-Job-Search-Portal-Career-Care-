using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataBase;

namespace CareCare.Controllers
{
    public class CompanyHomeController : Controller
    {
        private CareerCareDBEntities connection = new CareerCareDBEntities();

        public bool BadWordCheck(string Commnet)
        {

            string[] arr = { "F*ck", "F*ck you", "Shit", "Piss off", "Dick head", "Asshole", "Bastard", "Bitch", "sala", "kutta", "fuck", "Fuck", "bodmaish", "rubbish" };

            bool res = arr.AsQueryable().Contains(Commnet);
            if (res)
            {
                return true;
            }
            else
            {
                return false;
            }



        }
        // GET: CompanyHome

        public ActionResult CmpIndex()
        {

            if (Session["CmpEmail"] == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                string email = Session["CmpEmail"].ToString();
                CompanyProfile profile = connection.CompanyProfile.Where(data => data.CmpEmail.Equals(email)).FirstOrDefault();



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
                Imx.filter2 = profile;
                Imx.filter3 = blogpost;

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


        public ActionResult CmpAbout()
        {

            if (Session["CmpEmail"] == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                string email = Session["CmpEmail"].ToString();
                CompanyProfile profile = connection.CompanyProfile.Where(data => data.CmpEmail.Equals(email)).FirstOrDefault();



                return View(profile);
            }


            return View();
        }

        public ActionResult CmpContact()
        {

            if (Session["CmpEmail"] == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                string email = Session["CmpEmail"].ToString();
                CompanyProfile profile = connection.CompanyProfile.Where(data => data.CmpEmail.Equals(email)).FirstOrDefault();



                return View(profile);
            }


            return View();
        }

        public ActionResult CmpUpdateInfo()
        {

            if (Session["CmpEmail"] == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                string email = Session["CmpEmail"].ToString();
                CompanyProfile profile = connection.CompanyProfile.Where(data => data.CmpEmail.Equals(email)).FirstOrDefault();



                return View(profile);
            }


            return View();
        }



        [HttpPost]
        public ActionResult CmpUpdateInfo(CompanyProfile CmpProfile)
        {

            CompanyProfile existingProfile = connection.CompanyProfile.Where(data => data.CmpPassword.Equals(CmpProfile.CmpPassword)).FirstOrDefault();
            if (existingProfile != null)
            {
                existingProfile.CmpName = CmpProfile.CmpName;
                existingProfile.CmpHeadQ = CmpProfile.CmpHeadQ;
                existingProfile.CmpEmail = CmpProfile.CmpEmail;
                existingProfile.CmpContact = CmpProfile.CmpContact;
                existingProfile.CmpFounded = CmpProfile.CmpFounded;
                existingProfile.CmpFounders = CmpProfile.CmpFounders;
                existingProfile.CmpCeo = CmpProfile.CmpCeo;
                existingProfile.CmpWebsite = CmpProfile.CmpWebsite;
                existingProfile.CmpDescription = CmpProfile.CmpDescription;
                existingProfile.CmpPassword = CmpProfile.CmpNewPassword;


                //string filename = Path.GetFileNameWithoutExtension(jobSeeker.Cover.FileName);
                //string extension = Path.GetExtension(jobSeeker.Cover.FileName);
                //filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                //jobSeeker.imagepath = "~/ImgUploaded/" + filename;
                //filename = Path.Combine(Server.MapPath("~/ImgUploaded/"), filename);
                //jobSeeker.Cover.SaveAs(filename);
                //connection.JobSeeker_profile.Add(jobSeeker);



                string filename = Path.GetFileNameWithoutExtension(CmpProfile.Cover.FileName);
                string extension = Path.GetExtension(CmpProfile.Cover.FileName);
                filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                existingProfile.CmpLogo = "~/ImgUploaded/" + filename;
                filename = Path.Combine(Server.MapPath("~/ImgUploaded/"), filename);
                CmpProfile.Cover.SaveAs(filename);
                //connection.JobSeeker_profile.Add(existingProfile);
                connection.SaveChanges();
                return RedirectToAction("CmpIndex", "CompanyHome", "existingProfile");

            }

            return View("Error");


        }


        public ActionResult CmpShowInfo()
        {
            if (Session["CmpEmail"] == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                string email = Session["CmpEmail"].ToString();
                CompanyProfile profile = connection.CompanyProfile.Where(data => data.CmpEmail.Equals(email)).FirstOrDefault();



                return View(profile);
            }

            return View();
        }

        public ActionResult CmpJobPost()
        {
            if (Session["CmpEmail"] == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                string email = Session["CmpEmail"].ToString();
                CompanyProfile profile = connection.CompanyProfile.Where(data => data.CmpEmail.Equals(email)).FirstOrDefault();



                return View(profile);
            }


            return View();



        }



        [HttpPost]
        public ActionResult CmpJobPostData(JobPost job)
        {
            if (ModelState.IsValid)
            {
                job.CmpId = Convert.ToInt32(Session["CmpId"]);
                connection.JobPost.Add(job);
                connection.SaveChanges();
                //return RedirectToAction("JobSeekerReg");
                return RedirectToAction("CmpIndex");

            }


            return View("Error");
        }
        [HttpGet]
        public ActionResult CmpDeleteJob(int jobid)
        {

            JobPost job = connection.JobPost.Where(data => data.JobId.Equals(jobid)).FirstOrDefault();
            connection.JobPost.Remove(job);
            connection.SaveChanges();
            return RedirectToAction("CmpPostedJobTable", "CompanyHome");
        }


        public ActionResult CmpBlogPost()
        {
            if (Session["CmpEmail"] == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                string email = Session["CmpEmail"].ToString();
                CompanyProfile profile = connection.CompanyProfile.Where(data => data.CmpEmail.Equals(email)).FirstOrDefault();



                return View(profile);
            }

            return View();
        }

        [HttpPost]
        public ActionResult CmpBlogPostData(Blog blog)
        {

            if (ModelState.IsValid)
            {
                blog.CmpId = Convert.ToInt32(Session["CmpId"]);
               blog.BlogDes= blog.BlogDes.ToString();



                //return RedirectToAction("JobSeekerReg");


                string filename = Path.GetFileNameWithoutExtension(blog.Cover.FileName);
                string extension = Path.GetExtension(blog.Cover.FileName);
                filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                blog.BlogImgPath = "~/ImgUploaded/" + filename;
                filename = Path.Combine(Server.MapPath("~/ImgUploaded/"), filename);
                blog.Cover.SaveAs(filename);
                //connection.JobSeeker_profile.Add(existingProfile);
                connection.Blog.Add(blog);
                //connection.SaveChanges();
                try
                {
                    connection.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    Console.WriteLine(e); //eikhaner error er kahni hoitache je ami blog des er size onk choto dia dici.aro besi dite hoibo
                }


                return RedirectToAction("CmpIndex", "CompanyHome");

            }

            return View("Error");

        }

        public ActionResult CmpBlogList(string filterkey)
        {
            if (Session["CmpEmail"] == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                string email = Session["CmpEmail"].ToString();
                CompanyProfile profile = connection.CompanyProfile.Where(data => data.CmpEmail.Equals(email)).FirstOrDefault();
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

        public ActionResult CmpSingleBlogDetails(int blogid)
        {
            if (Session["CmpEmail"] == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                string email = Session["CmpEmail"].ToString();
                CompanyProfile profile = connection.CompanyProfile.Where(data => data.CmpEmail.Equals(email)).FirstOrDefault();


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
        public ActionResult CmpBlogComment(BlogComments Cmnt)
        {
            if (BadWordCheck(Cmnt.Comment))
            {

                return RedirectToAction("CmpIndex", "CompanyHome");
            }
            else
            {
                Cmnt.React = Convert.ToInt32(Cmnt.React);
                Cmnt.Comment = Cmnt.Comment.ToString();
                string email = Session["CmpEmail"].ToString();
                CompanyProfile profile = connection.CompanyProfile.Where(data => data.CmpEmail.Equals(email)).FirstOrDefault();
                Cmnt.CommenterName = profile.CmpName;
                Cmnt.CommenterPic = profile.CmpLogo;
                connection.BlogComments.Add(Cmnt);
                connection.SaveChanges();
                return RedirectToAction("CmpSingleBlogDetails", "CompanyHome", new { blogid = Cmnt.BlogId });

            }

        }



        public ActionResult CmpPostedJobTable()
        {
            if (Session["CmpEmail"] == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                string email = Session["CmpEmail"].ToString();
                CompanyProfile profile = connection.CompanyProfile.Where(data => data.CmpEmail.Equals(email)).FirstOrDefault();
                int CmpId = Convert.ToInt32(profile.CmpId);


                List<JobPost> jobs = new List<JobPost>();              
                List<CompanyProfile> cmprofile = new List<CompanyProfile>();
                jobs = (from s in connection.JobPost
                        join sa in connection.CompanyProfile on s.CmpId equals sa.CmpId
                        where s.CmpId == CmpId
                        select s).ToList();

                List<JobPost> JobObj = new List<JobPost>();
                List<Applications> ApplyObj = new List<Applications> ();
                List<Applications> counting = new List<Applications>();
                ApplyObj = (from s in connection.Applications
                            join sa in connection.JobPost on s.JobId equals sa.JobId where s.JobId == sa.JobId
                            select s
                             ).ToList();


                counting = ApplyObj.Where(data => data.JobPost.CmpId.Equals(CmpId)).ToList();

                int totaljobposted = jobs.Count;
                int[] arr = new int[totaljobposted];
                for (int i=0;i<totaljobposted; i++)
                {
                    arr[i] = counting.Where(data => data.JobId.Equals(jobs[i].JobId)).ToList().Count;

                }
                ViewBag.NoOfApply=arr;




                dynamic Imx = new System.Dynamic.ExpandoObject();
                Imx.filter1 = jobs;
                Imx.filter2 = profile;

                return View(Imx);


            }
        }






    }
}