using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelEF.DAO;
using PagedList;
using ModelEF;
using ModelEF.Model;

namespace TestUngDung.Areas.Admin.Controllers
{
    public class SanPhamController : BaseController
    { BachTrungKienContext db = new BachTrungKienContext();
        // GET: Admin/SanPham
        public ActionResult Index(int page = 1, int pagesize = 5)
        {
            var sp = new SanPhamDao();
            var model = sp.ListAll();
            return View(model.ToPagedList(page, pagesize));
        }



        [HttpPost]
        public ActionResult Index(string searchString, int page = 1, int pagesize = 5)
        {
            var dm = new SanPhamDao();
            var model = dm.ListWhereAll(searchString, page, pagesize);
            @ViewBag.SearchString = searchString;
            return View(model.ToPagedList(page, pagesize));
        }


        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}


        [HttpGet]
        public ActionResult Create(string SanPham)
        {
            var dao = new SanPhamDao();
            var result = dao.Find(SanPham);
            if (result != null)
                return View(result);
            return View();
        }


        [HttpPost]
        public ActionResult Create(Product   model)
        {
            if (ModelState.IsValid)
            {
                var dao = new SanPhamDao();
                var masp = model.Name;
                model.Name = masp;
                string result;

                result = dao.Insert(model);

                if (!string.IsNullOrEmpty(result))
                {
                    SetAlert("Cập nhật sản phẩm thành công", "success");
                    return RedirectToAction("Index", "SanPham");
                }
                else
                {
                    SetAlert("Cập nhật sản phẩm không thành công", "error");
                    
                }
            }
            return View();
        }


        [HttpDelete]
        public ActionResult Delete(string sanpham)
        {
            var dao = new SanPhamDao().Delete(sanpham);
            return RedirectToAction("Index");
        }
        public ActionResult  ChooseCategory()
        {
            Category cate = new Category();
            cate.CateCollection = db.Categories.ToList<Category>();
            return PartialView(cate);
        }
        public ActionResult Detail(int id)
        {
            return View();
        }
    }
}