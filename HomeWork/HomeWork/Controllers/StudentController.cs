using HomeWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWork.Controllers
{
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
        public ActionResult Yuxi()
        {
            //if (homeworkType == 1)
            //{
            //    //List<QueryHomeWork> list = student.selectYuxi(studentNo, chapterId);
            //    //ViewBag.yuxi = list;
            //    return PartialView("Yuxi");
            //}
            //if (homeworkType == 2)
            //{
            //    return PartialView("Yuxi");
            //}
            //if (homeworkType == 3)
            //{
            //    return PartialView("Yuxi");
            //}

            return PartialView("Yuxi");
        }
        public ActionResult Yuntiku()
        {
            return PartialView("Yuntiku");
        }
        public ActionResult Lianxi()
        {
            return PartialView("Lianxi");
        }
    }
}
