using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class CategoryDao
    {
        private BachTrungKienContext db;
        public CategoryDao()
        {
            db = new BachTrungKienContext();
        }
        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }
    }
}
