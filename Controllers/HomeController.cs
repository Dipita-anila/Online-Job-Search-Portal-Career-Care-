using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataBase;

namespace CareCare.Controllers
{
    public class HomeController : Controller
    {
       private CareerCareDBEntities connection = new CareerCareDBEntities();


        [HttpGet]
        public ActionResult Index(string  Title, string location)
        {
            Session.Clear();
            
            if(location !=null)
            {
                //Title = Title.ToString();
                location = location.ToString();
                List<JobPost> jobs = new List<JobPost>();
                List<JobPost> FilterByKyword = new List<JobPost>();
                List<CompanyProfile> cmprofile = new List<CompanyProfile>();
                List<Blog>blogpost=new List<Blog>();
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
                Imx.filter3 = blogpost;




                List<JobPost>DesignCreativeJobs= new List<JobPost>();
                List<JobPost>ConstructionJobs= new List<JobPost>();
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
                ViewBag.Nconstruction   = ConstructionJobs.Count;
                ViewBag.Ndesigndevelopment = DesignDevelopmentJobs.Count;
                ViewBag.Nsalesmarketing = SalesMarketingJobs.Count;
                ViewBag.Nmobileapplication = MobileApplicationJobs.Count;
                ViewBag.Ncontentwriter = ContentWriterJobs.Count;
                ViewBag.Ninformationtechnology = InformationTechnologyJobs.Count;
                ViewBag.Nrealestate = RealEstateJobs.Count;


                return View(Imx);


            }else
            {

                List<JobPost> jobs = new List<JobPost>(); 
                List<Blog> blogpost = new List<Blog>();

                List<CompanyProfile> cmprofile = new List<CompanyProfile>();
                jobs = (from s in connection.JobPost
                        join sa in connection.CompanyProfile on s.CmpId equals sa.CmpId
                        select s).ToList();
                var blogsql = "SELECT TOP 1 * FROM Blog";
                blogpost = connection.Blog.SqlQuery(blogsql).ToList();


                dynamic Imx = new System.Dynamic.ExpandoObject();
                Imx.filter1 = jobs;
                Imx.filter2 = null;
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
        //[HttpPost]
        //public ActionResult Index(string Title , string location)
        //{
        //    Title = Title.ToString();
        //    location = location.ToString();


        //    List<JobPost> jobs = new List<JobPost>();
        //    List<JobPost> FilterByKyword = new List<JobPost>();
        //    List<CompanyProfile> cmprofile = new List<CompanyProfile>();
        //    jobs = (from s in connection.JobPost
        //            join sa in connection.CompanyProfile on s.CmpId equals sa.CmpId
        //            select s).ToList();
        //    FilterByKyword = (from s in connection.JobPost
        //                      join sa in connection.CompanyProfile on s.CmpId equals sa.CmpId
        //                      where s.JobLocation == location
        //                      select s).ToList();

        //    dynamic Imx = new System.Dynamic.ExpandoObject();
        //    Imx.filter1 = jobs;
        //    Imx.filter2 = FilterByKyword;


        //    return View(Imx);
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }



        public ActionResult FindJob(String Category , String JobType, String JobLocation , string Experience)
        {
            if(Category == null && JobType == null && JobLocation == null && Experience == null)
            {

                List<JobPost> jobs = new List<JobPost>();              
                List<CompanyProfile> cmprofile = new List<CompanyProfile>();
                jobs = (from s in connection.JobPost
                        join sa in connection.CompanyProfile on s.CmpId equals sa.CmpId
                        select s).ToList();
                dynamic Imx = new System.Dynamic.ExpandoObject();
                Imx.filter1 = jobs;
                ViewBag.ResultsCount = jobs.Count;

                return View(Imx);

            }else if(Category != null || JobType != null || JobLocation != null || Experience != null)
            {

                //Title = Title.ToString();


                List<JobPost> FilterByCategory = new List<JobPost>();
                List<CompanyProfile> cmprofile = new List<CompanyProfile>();
                if(Category != null && JobType != null && JobLocation != null && Experience != null)
                {

                    FilterByCategory = (from s in connection.JobPost
                                        join sa in connection.CompanyProfile on s.CmpId equals sa.CmpId
                                        where s.JobTag == Category && s.JobLocation == JobLocation && s.JobNature == JobType && s.JobExperience == Experience
                                        select s).ToList();

                    dynamic Imx = new System.Dynamic.ExpandoObject();
                    ViewBag.ResultsCount = FilterByCategory.Count;

                    Imx.filter1 = FilterByCategory;


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

                    Imx.filter1 = FilterByCategory;


                    return View(Imx);


                }




            }

            return View();
        }

        public ActionResult JobDetails(int jobid)
        {

            List<JobPost> jobs = new List<JobPost>();

            List<CompanyProfile> cmprofile = new List<CompanyProfile>();
            jobs = (from s in connection.JobPost
                    join sa in connection.CompanyProfile on s.CmpId equals sa.CmpId
                    where s.JobId == jobid
                    select s).ToList();


            dynamic Imx = new System.Dynamic.ExpandoObject();
            Imx.filter1 = jobs;
            

            return View(Imx);


        }

        public ActionResult BlogList(string filterkey)
        {
            if(filterkey==null)
            {
                List<Blog> blogpost = new List<Blog>();
            
                var blogsql = "SELECT  * FROM Blog";
                blogpost = connection.Blog.SqlQuery(blogsql).ToList();
               

                dynamic Imx = new System.Dynamic.ExpandoObject();
                Imx.filter1 = blogpost;


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
                List<Blog>filteredBlog = new List<Blog>();
                filteredBlog = connection.Blog.Where(data => data.BlogCatag.Equals(filterkey)).ToList();
                dynamic Imx = new System.Dynamic.ExpandoObject();
                Imx.filter1 = filteredBlog;



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


            return View();
        }


        public ActionResult SingleBlogDetails(int blogid)
        {
            blogid = Convert.ToInt32(blogid);
          List<Blog> BlogDetails = new List<Blog>();
            List<BlogComments> blogcomments = new List<BlogComments>();

           
            BlogDetails = connection.Blog.Where(data => data.BlogId.Equals(blogid)).ToList();

            blogcomments = (from s in connection.BlogComments
                           join sa in connection.Blog on s.BlogId equals sa.BlogId where s.BlogId == blogid
                           select s).ToList();

            ViewBag.CmntCnt = blogcomments.Count;



            dynamic Imx = new System.Dynamic.ExpandoObject();
            Imx.filter1 = BlogDetails;
            Imx.filter2 = blogcomments;


            return View(Imx);

        }



        public ActionResult NewsList()
        {

            return View();
        }




        public ActionResult Contact()
        {
            //ViewBag.Message = "Your contact page.";
           

            return View();
        }





















        public ActionResult JoingCheck()
        {
            string d = "dhaka".ToString();


            List<JobPost>jobs=new List<JobPost>();
            List<JobPost> FilterByKyword = new List<JobPost>();
            List<CompanyProfile> cmprofile=new List<CompanyProfile>();
             jobs = (from s in connection.JobPost
                                    join sa in connection.CompanyProfile on s.CmpId equals sa.CmpId                                   
                                    select s).ToList();
            FilterByKyword = (from s in connection.JobPost
                              join sa in connection.CompanyProfile on s.CmpId equals sa.CmpId
                              where s.JobLocation ==d
                              select s).ToList();

            dynamic Imx = new System.Dynamic.ExpandoObject();
            Imx.filter1 = jobs;
            Imx.filter2 = FilterByKyword;        


            return View(Imx);
        }


        public ActionResult Registration()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Registration(Registration reg)
        {
           
            if(ModelState.IsValid)
            {
                connection.Registration.Add(reg);
                connection.SaveChanges();
                RedirectToAction("Login");
            }

            return View();
        }




        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(Registration logobj)
        {
            var checklogin = connection.Registration.Where(temp => temp.Email.Equals(logobj.Email) && temp.Passwd.Equals(logobj.Passwd)).FirstOrDefault();

            if (checklogin != null)
            {
                Session["Name"] = logobj.Name;
                Session["Email"] = logobj.Email.ToString();
              
                return RedirectToAction("contact", "Home");
            }

            return View();
        }

    }
}