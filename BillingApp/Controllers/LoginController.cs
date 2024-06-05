using BillingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace BillingApp.Controllers
{
    public class LoginController : Controller
    {
        BillingDBEntities db = new BillingDBEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(AccountModel l)
        {
            var query = db.Users.SingleOrDefault(m => m.UserName == l.UserName && m.Password == l.Password);
            if (query != null)
            {
                Response.Write("<script>alert('Login Successfully')</script>");
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Response.Write("<script>alert('Invalid Credential')</script>");
                return View(l);
            }
            return View(l);
        }
    }
}