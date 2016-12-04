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
        /// 查询书本
        /// </summary>
        /// <returns></returns>
        public List<Model.Subject> selectSubjects()
        {
            return context.Subjects.ToList();
        }
        /// <summary>
        /// /查询作业类型
        /// </summary>
        /// <returns></returns>
        public List<Model.HomeworkType> selectType()
        {
            return context.HomeworkTypes.ToList();
        }
        /// <summary>
        /// 查询作业
        /// </summary>
        /// <param name="studentNo"></param>
        /// <param name="chapterId"></param>
        /// <returns></returns>
        public List<QueryHomeWork> executeQuery(int studentNo, int? subjectId, int? homeWorkTypeId)
        {
            if (subjectId == null)
            {
                var homework = from u in context.Homework
                               where u.StudentNo == studentNo && u.HomeworkTypeId == homeWorkTypeId
                               select new QueryHomeWork()
                               {
                                   Comment = u.Comment,
                                   ScoreName = u.Score.ScoreName,
                                   Speed = u.Speed,
                                   StudentName = u.Student.StudentName,
                                   UploadFileName = u.UploadFile.UploadFileName,
                                   Describe = u.UploadFile.Describe,
                                   UploadFilePath = u.UploadFile.UploadFilePath,
                                   UploadTime = u.UploadFile.UploadTime,
                                   ChapterName = u.Chapter.ChapterName
                               };
                return homework.ToList();
            }
            else
            {
                var homework = from u in context.Homework
                               where u.StudentNo == studentNo && u.Chapter.SubjectId == subjectId && u.HomeworkTypeId == homeWorkTypeId
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
        /// <summary>
        /// 查询章节
        /// </summary>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        public List<Model.Chapter> chapter(int subjectId)
        {
            return context.Chapters.Where(m => m.SubjectId == subjectId).Select(m => m).ToList();
        }
        /// <summary>
        /// 添加上机练习
        /// </summary>
        /// <param name="lx"></param>
        /// <returns></returns>
        public bool AddLianXi(LianXi lx)
        {
            //插入文件信息
            var file = new UploadFile()
            {
                UploadTime = DateTime.Now,
                UploadFileName = lx.UploadFileNamelx,
                Describe = lx.Describelx,
                UploadFilePath = lx.UploadFilePath
            };
            context.UploadFiles.Add(file);
            //如果插入文件成功则继续插入作业信息
            if (context.SaveChanges() > 0)
            {
                var uploadFileId = Convert.ToInt32((context.UploadFiles.Where(s => s.UploadFilePath == lx.UploadFilePath).Select(m => m.UploadFileId).ToList())[0]);
                //int uploadFileId = Convert.ToInt32();
                var lianXi = new Homework()
                {
                    StudentNo = lx.StudentNo,
                    ChapterId = lx.ChapterId,
                    HomeworkTypeId = lx.HomeworkTypeId,
                    Speed = lx.Speedlx,
                    UploadFileId = uploadFileId
                };
                context.Homework.Add(lianXi);
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 添加云题库
        /// </summary>
        /// <param name="uploadFileName"></param>
        /// <returns></returns>
        public bool AddYTK(YTK ytk)
        {
            var file = new UploadFile()
            {
                UploadFileName = ytk.uploadFileName,
                UploadFilePath = ytk.uploadFilePath,
                UploadTime = DateTime.Now,
                Describe = ytk.Describeyt
            };
            context.UploadFiles.Add(file);
            if (context.SaveChanges() > 0)
            {
                var uploadFileId = Convert.ToInt32((context.UploadFiles.Where(s => s.UploadFilePath == ytk.uploadFilePath).Select(m => m.UploadFileId).ToList())[0]);
                var yt = new Homework()
                {
                    StudentNo = ytk.studentNo,
                    HomeworkTypeId = 3,
                    UploadFileId = uploadFileId
                };
                context.Homework.Add(yt);
                if (context.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 添加预习总结
        /// </summary>
        /// <param name="yx"></param>
        /// <returns></returns>
        public bool AddYuXi(YuXi yx)
        {
            //插入文件信息
            var file = new UploadFile()
            {
                UploadTime = DateTime.Now,
                UploadFileName = yx.UploadFileNameyx,
                Describe = yx.Describeyx,
                UploadFilePath = yx.UploadFilePath
            };
            context.UploadFiles.Add(file);
            //如果插入文件成功则继续插入作业信息
            if (context.SaveChanges() > 0)
            {
                var yxzj = new YXZJ()
                {
                    Z_Have = yx.Z_Have,
                    Z_NotHave = yx.Z_NotHave,
                    Y_Have = yx.Y_Have,
                    Y_NotHave = yx.Y_NotHave
                };
                context.YXZJs.Add(yxzj);
                if (context.SaveChanges() > 0)
                {
                    var uploadFileId = Convert.ToInt32((context.UploadFiles.Where(s => s.UploadFilePath == yx.UploadFilePath).Select(m => m.UploadFileId).ToList())[0]);
                    var yxzjId = (from a in context.YXZJs
                                 orderby a.YXZJId descending
                                 select a.YXZJId).ToList()[0];
                    //int uploadFileId = Convert.ToInt32();
                    var Yuxi = new Homework()
                    {
                        StudentNo = yx.StudentNo,
                        ChapterId = yx.ChapterId,
                        HomeworkTypeId = yx.HomeworkTypeId,
                        UploadFileId = uploadFileId,
                        YXZJId = yxzjId
                    };
                    context.Homework.Add(Yuxi);
                    if (context.SaveChanges() > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
