using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public static class AdminLoginBLL
    {
        public static string GetAdminPwd(string adminName)
        {
            Admin admin=AdminDAL.SelectAdminByAdminName(adminName);
            return admin.AdminPwd;
        }
    }
}
