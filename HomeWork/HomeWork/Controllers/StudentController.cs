using HomeWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWork.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        BLL.Student student = new BLL.Student();
        //
        // GET: /Student/

        public ActionResult Index()
        {
            //作业类型下拉框
            List<HomeworkType> type = student.selectType();
            SelectList typelist = new SelectList(type, "HomeworkTypeId", "HomeworkName");
            ViewBag.typelist = typelist;
            //书本下拉框
            List<Subject> subjects = student.selectSubjects();
            SelectList list = new SelectList(subjects, "SubjectId", "SubjectName");
            ViewBag.list = list;

            return View();
        }
        public ActionResult List()
        {
            return PartialView("List");
        }
        /// <summary>
        /// 查询作业
        /// </summary>
        /// <param name="HomeworkTypeId"></param>
        /// <param name="subjectId"></param>
        /// <returns></returns>
        public ActionResult ChaXun(int HomeworkTypeId, int? subjectId)
        {
            int studentNo = Convert.ToInt32(this.User.Identity.Name);
            List<QueryHomeWork> list = student.executeQuery(studentNo, subjectId, HomeworkTypeId);
            ViewBag.yuxi = list;
            return PartialView("WorkList");
        }
        public ActionResult Yuxi()
        {

            return PartialView("Yuntiku");
        }

        public ActionResult Yuntiku()
        {
            return PartialView("Yuntiku");
        }
        public ActionResult Lianxi()
        {
            return PartialView("Lianxi");
        }

        public ActionResult ShowChapter(int? subjectId)
        {
            int subjectIds = subjectId.HasValue ? Convert.ToInt32(subjectId) : 22;
            //章节下拉框
            List<Chapter> chapters = student.chapter(subjectIds);
            ViewBag.chapter = chapters;
            return PartialView("ShowChapter");
        }
    }
}
