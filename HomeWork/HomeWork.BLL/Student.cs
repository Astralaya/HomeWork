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
        public List<Model.HomeworkType> selectType()
        {
            return student.selectType();
        }
        public List<Subject> selectSubjects() 
        {
            return student.selectSubjects();
        }
        public List<QueryHomeWork> executeQuery(int studentNo, int? subjectId, int? homeWorkTypeId)
        {
            return student.executeQuery(studentNo, subjectId, homeWorkTypeId);
        }
        public List<Model.Chapter> chapter(int subjectId)
        {
            return student.chapter(subjectId);
        }
        public bool AddLianXi(LianXi lx)
        {
            return student.AddLianXi(lx);
        }
    }
}
