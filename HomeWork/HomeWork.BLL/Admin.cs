using HomeWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.BLL
{
    public class Admin
    {
        static DAL.Admin admin = new DAL.Admin();
        public static Administrator existUser(LoginUser lu)
        {
            return admin.existUser(lu);
        }
    }
}
