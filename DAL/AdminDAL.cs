using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public static class AdminDAL
    {
        private static OwDBContext db = new OwDBContext();

        public static bool InsertAdmin(Admin admin)
        {
            try
            {
                db.Admin.Add(admin);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public static bool DeleteAdmin(string adminName)
        {
            try
            {
                Admin admin=db.Admin.Find(adminName);
                db.Admin.Remove(admin);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool UpdateAdmin(string oldAdminName, Admin admin)
        {
            try 
            {
                Admin oldAdmin = db.Admin.Find(oldAdminName);
                oldAdmin.AdminName = admin.AdminName;
                oldAdmin.AdminPwd = admin.AdminPwd;
                db.SaveChanges();
                return true;
            }
            catch (Exception) 
            {
                return false;
            }
        }

        public static Admin SelectAdminByAdminName(string adminName)
        {
            try
            {
                IQueryable<Admin> admin = from a in db.Admin where a.AdminName == adminName select a;
                return admin.ToList()[0];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static List<Admin> SelectAllAdmin()
        {
            return db.Admin.ToList();
        }

    }
}
