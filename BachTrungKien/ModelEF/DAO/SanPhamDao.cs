using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelEF.DAO
{
    public class SanPhamDao
    {
        private BachTrungKienContext db;

        public SanPhamDao()
        {
            db = new BachTrungKienContext();
        }


        public string Insert(Product entitySP)
        {
            db.Products.Add(entitySP);
            db.SaveChanges();
            return entitySP.Name;
        }

        public bool Delete(string name)
        {
            try
            {
                var sanpham = db.Products.Find(name);
                db.Products.Remove(sanpham);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public Product Find(string name)
        {

            return db.Products.Find(name);
        }


        public List<Product> ListAll()
        {
            var list = db.Database.SqlQuery<Product>("Sp_Product_ListAll").ToList();
                return list;
        }


        public IEnumerable<Product> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<Product> model = db.Products;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.Name.Contains(keysearch));
            }
            return model.OrderBy(x => x.Name).ToPagedList(page, pagesize);
        }
    }
}
