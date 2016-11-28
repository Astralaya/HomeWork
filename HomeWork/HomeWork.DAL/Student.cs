using HomeWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.DAL
{
    public class Student
    {
        HomeWorkEntities context = new HomeWorkEntities();
        /// <summary>
        /// 检查学生是否存在
        /// </summary>
        /// <param name="lu"></param>
        /// <returns></returns>
        public Model.Student existUser(LoginUser lu)
        {
            return context.Students.SingleOrDefault(s => s.StudentName == lu.UserName && s.Password == lu.Password);
        }
        /// <summary>
        /// 查询书本下拉框
        /// </summary>
        /// <returns></returns>
        public List<Chapter> selectChapter()
        {
            return context.Chapters.ToList();
        }
        /// <summary>
        /// 查询预习总结
        /// </summary>
        /// <param name="studentNo"></param>
        /// <param name="chapterId"></param>
        /// <returns></returns>
        public List<QueryHomeWork> selectYuxi(int studentNo, int chapterId)
        {
            var homework = from u in context.Homework
                           where u.StudentNo == studentNo && u.ChapterId == chapterId
                           select new QueryHomeWork()
                           {
                               Comment = u.Comment,
                               ScoreName = u.Score.ScoreName,
                               Speed = u.Speed,
                               StudentName = u.Student.StudentName,
                               UploadFileName = u.UploadFile.UploadFileName,
                               Describe = u.UploadFile.Describe,
                               UploadFilePath = u.UploadFile.UploadFilePath,
                               UploadTime = u.UploadFile.UploadTime
                           };
            return homework.ToList();
        }
    }
}
