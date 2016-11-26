using HomeWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.BLL
{
    public class Student
    {
        static DAL.Student student = new DAL.Student();
        public static Model.Student existUser(LoginUser lu)
        {
            return student.existUser(lu);
        }
    }
}
