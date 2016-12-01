using HomeWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeWork.BLL;

namespace HomeWork.Controllers
{
     [Authorize]
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/
        HomeWorkEntities context = new HomeWorkEntities();
        BLL.Student student = new BLL.Student();
        BLL.Class classBll = new BLL.Class();
        public ActionResult Index()
        {

            //书本下拉框
            List<Subject> subjects = student.selectSubjects();
            SelectList list = new SelectList(subjects, "SubjectId", "SubjectName");
            ViewBag.list = list;
            //班级下拉框
            List<HomeWork.Model.Class> classResult = classBll.getAllClass();
            SelectList list2 = new SelectList(classResult, "ClassId", "ClassName");
            ViewBag.list2 = list2;

            return View();
        }

        //章节下拉框
        public ActionResult ShowChapter(string subjectId)
        {
            BLL.Chapter chapter = new BLL.Chapter();

            List<HomeWork.Model.Chapter> result = chapter.getChapterBySubjectId(subjectId == null ? 22 : Convert.ToInt32(subjectId));

            ViewBag.chapter = result;
            return PartialView("ShowChapter");
        }



        //教员查询结果
        public ActionResult TeacherQuery(string type, string ClassId, string SubjectId, string chapter)
        {

            int id = Convert.ToInt32(type);
            int Subject = Convert.ToInt32(SubjectId);
            int classid = Convert.ToInt32(ClassId);
            if (chapter != "" && chapter != null)
            {
                int chapterid = Convert.ToInt32(chapter);
                var list = from item in context.Homework.Where(p => (p.HomeworkTypeId == id && p.Student.ClassId == classid && p.ChapterId == chapterid))
                           select new TeacherQuery()
                           {
                               StudentName = item.Student.StudentName,
                               Speed = item.Speed,
                               Comment = item.Comment,
                               ScoreName = item.Score.ScoreName,
                               UploadFilePath = item.UploadFile.UploadFilePath,
                               UploadTime = item.UploadFile.UploadTime,
                               Describe = item.UploadFile.Describe,
                               UploadFileName = item.UploadFile.UploadFileName,
                               ChapterName = item.Chapter.ChapterName

                           };
                IEnumerable<TeacherQuery> items = list.ToList();
                return PartialView("TeacherQuery", items);
            }
            else if (chapter == "")
            {
                var list = from item in context.Homework.Where(p => (p.HomeworkTypeId == id && p.Student.ClassId == classid && p.Chapter.SubjectId == Subject))
                           select new TeacherQuery()
                           {
                               StudentName = item.Student.StudentName,
                               Speed = item.Speed,
                               Comment = item.Comment,
                               ScoreName = item.Score.ScoreName,
                               UploadFilePath = item.UploadFile.UploadFilePath,
                               UploadTime = item.UploadFile.UploadTime,
                               Describe = item.UploadFile.Describe,
                               UploadFileName = item.UploadFile.UploadFileName,
                               ChapterName = item.Chapter.ChapterName

                           };

                IEnumerable<TeacherQuery> items = list.ToList();
                return PartialView("TeacherQuery", items);
            }

            return PartialView("TeacherQuery");

        }


    }
}
