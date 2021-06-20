using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Models;
using ModelEF.DAO;
using ModelEF;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel login)
        {
            if(ModelState.IsValid)
            {
                var user = new UserDao();
                var result = user.login(login.username,Common.EncryptorMD5(login.password))
;
                if( result ==1)
                {
                    //ModelState.AddModelError("", "Đăng nhập thành công");
                    Session.Add(Constants.USER_SESSION, login.username);
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Đăng nhập thất bại");
            }
            return View();
        }
    }
}