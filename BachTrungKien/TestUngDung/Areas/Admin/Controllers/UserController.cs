using ModelEF;
using ModelEF.DAO;
using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestUngDung.Areas.Admin.Models;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        // GET: Admin/User
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var user = new UserDao();
            var model = user.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }



        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var user = new UserDao();
            var model = user.ListWhereAll(searchString, page, pagesize);
            @ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }
        [HttpGet]
        public  ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserAccount model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
               
                var pass = Common.EncryptorMD5(model.Password);
                model.Password = pass;
                var status = model.Status;
                model.Status = status;
                string result;
                result = dao.Insert(model);

                if (!string.IsNullOrEmpty(result))
                {
                    SetAlert("Cập nhật người dùng thành công", "success");
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    SetAlert("Cập nhật người dùng không thành công", "error");

                }
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(string username)
        {
            var dao = new UserDao().Delete(username);
            return RedirectToAction("Index");
        }
        
    }
}