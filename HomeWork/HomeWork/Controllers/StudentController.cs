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
        public ActionResult ChaXun(int HomeworkTypeId, int subjectId)
        {
            int studentNo = Convert.ToInt32(this.User.Identity.Name);
            //预习总结
            if (HomeworkTypeId == 1)
            {
                List<QueryHomeWork> list = student.selectYuxi(studentNo, subjectId);
                ViewBag.yuxi = list;
                return PartialView("WorkList");
            }
            //上机练习
            if (HomeworkTypeId == 2)
            {
                return PartialView("WorkList");
            }
            //云题库
            if (HomeworkTypeId == 3)
            {
                return PartialView("WorkList");
            }

            return PartialView("error");
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
    }
}
