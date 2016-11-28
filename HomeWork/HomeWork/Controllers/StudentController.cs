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
            List<Chapter> chap = student.selectChapter();
            SelectList list = new SelectList(chap, "ChapterId", "ChapterName");
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
