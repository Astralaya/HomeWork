using HomeWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.DAL
{
    /// <summary>
    /// 教师
    /// </summary>
    public class Teacher
    {
        QingNiaoEntities context = new QingNiaoEntities();
        /// <summary>
        /// 按 年级>班级 查询作业
        /// </summary>
        /// <returns></returns>
        public List<QueryHomeWork> executeQueryHomeWork(int chapterId,int homeWorkType)
        {
            if (homeWorkType == 1)
            {
                var query = from c in context.Homework
                            where c.ChapterId == chapterId
                            select new QueryHomeWork()
                            {
                                Comment = c.Comment,
                                Describe = c.UploadFile.Describe,
                                ScoreName = c.Score.ScoreName,
                                Speed = c.Speed,
                                StudentName = c.Student.StudentName,
                                UploadFilePath = c.UploadFile.UploadFilePath,
                                UploadTime = c.UploadFile.UploadTime,
                                UploadFileName = c.UploadFile.UploadFileName
                            };
                return query.ToList();
            }

            if (homeWorkType == 2)
            {
                return null;
            }

            if (homeWorkType == 3)
            {
                return null;
            }
            return null;
        }

    }
}
