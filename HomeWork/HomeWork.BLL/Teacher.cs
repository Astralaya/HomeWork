using HomeWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.BLL
{
    public class Teacher
    {
        static DAL.Teacher teacher = new DAL.Teacher();

        public static Model.Teacher existUser(LoginUser lu)
        {
            return teacher.existUser(lu);
        }
    }
}
