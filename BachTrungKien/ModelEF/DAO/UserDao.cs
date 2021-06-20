using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class UserDao
    {
        private BachTrungKienContext db;
        public UserDao()
        {
            db = new BachTrungKienContext();
        }
        public int login(string user,string pass)
        {
            var result = db.UserAccounts.SingleOrDefault(x => x.UsereName.Contains(user) && x.Password.Contains(pass));
            if (result == null)
                return 0;
            else
            return 1;
        }
        public string Insert(UserAccount entityUser)
        {
            db.UserAccounts.Add(entityUser);
            db.SaveChanges();
            return entityUser.UsereName;
        }

        public bool Delete(string username)
        {
            try
            {
                var user = db.UserAccounts.Find(username);
                db.UserAccounts.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public UserAccount Find(string username)
        {
            return db.UserAccounts.Find(username);
        }


        public List<UserAccount> ListAll()
        {
            return db.UserAccounts.ToList();
        }


        public IEnumerable<UserAccount> ListWhereAll(string keysearch, int page, int pagesize)
        {
            IQueryable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(keysearch))
            {
                model = model.Where(x => x.UsereName.Contains(keysearch));
            }
            return model.OrderBy(x => x.UsereName).ToPagedList(page, pagesize);
        }
    }
}
