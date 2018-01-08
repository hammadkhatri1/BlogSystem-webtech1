using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using webBlog.Models.viewModelBlog;

namespace webBlog.Controllers
{
    public class HomeController : Controller
    {
        DbWebBlog db = new DbWebBlog();

        public ActionResult Index()
        {
            vmBlog vm = new vmBlog();
            vm.posts = db.Posts.ToList();
            return View(vm);
        }

        public ActionResult createPost()
        {
            if (Session["UserName"] != null)
            {
                ViewBag.usernn = Session["UserName"];
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpPost]
        public ActionResult createPost(Post postinfo)
        {
          
            postinfo.postedBy = Session["UserName"].ToString();
            postinfo.dateCreated = DateTime.Now;

            db.Posts.Add(postinfo);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult postDetails(int id)
        {
            Session["mId"] = id;
            vmBlog vm = new vmBlog();

            vm.post = db.Posts.Where(p=> p.PostId==id).Single();
            vm.comments = db.comments.Where(c=>c.postId==id);

            return View(vm);
        }
        [HttpPost]
        public ActionResult postDetails(comment comm)
        {
            int id = Convert.ToInt32(Session["mId"]);
            if (Session["UserName"] != null)
            {
                comm.userName = Session["UserName"].ToString();
                comm.postId = id;
                comm.timePosted = DateTime.Now;

                db.comments.Add(comm);
                db.SaveChanges();
                return RedirectToAction("postDetails", new { mid = id });
            }
            else
            {
                ViewBag.ErrorMessage = "Please log in ";
                return RedirectToAction("postDetails", new { mid = id });
            }
        }
        
        
        public ActionResult Login()
        {
            if (Session["UserName"] != null)
            {
                ViewBag.ErrorMessage = "Already logged in ";
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount users)
        {
            if (ModelState.IsValid)
            {
                    var loginUser = db.UserAccounts.Where(u => u.userName.Equals(users.userName) && u.password.Equals(users.password)).ToArray();
                    
                    
                    if (loginUser.Length==1)
                    {
                        Session["UserName"] = users.userName.ToString();
                        return RedirectToAction("createPost");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "error username or password not found";  
                    }
                }
            
            return View(users);
        }
        public ActionResult Logout()
        {
            Session.Abandon(); 
            return RedirectToAction("index", "Home");
        }
    }
}