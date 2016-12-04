using HomeWork.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult ChaXun(int? HomeworkTypeId, int? subjectId)
        {
            int studentNo = Convert.ToInt32(this.User.Identity.Name);
            List<QueryHomeWork> list = student.executeQuery(studentNo, subjectId, HomeworkTypeId);
            return PartialView("WorkList", list);
        }


        /// <summary>
        /// 上机练习上传
        /// </summary>
        /// <param name="lx"></param>
        /// <param name="uploadFilelx"></param>
        /// <returns></returns>
        public ActionResult Lianxi(LianXi lx, HttpPostedFileBase uploadFilelx)
        {
            lx.HomeworkTypeId = 2;
            lx.StudentNo = Convert.ToInt32(this.User.Identity.Name);
            //设置文件名
            string fileName = lx.StudentNo + "/" + lx.StudentNo + "-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Millisecond + ".zip";
            //文件保存路径
            string path = Server.MapPath("~/WorkSpances/SJLX/" + lx.StudentNo + "/");
            //如果路径不存在则创建
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string uploadFilePath = "~/WorkSpances/SJLX/" + fileName;
            string uploadFilePathRe = Server.MapPath(uploadFilePath);
            lx.UploadFileNamelx = fileName;
            uploadFilelx.SaveAs(uploadFilePathRe);
            lx.UploadFilePath = uploadFilePath;
            student.AddLianXi(lx);
            return Content("<script>alert('上传成功！');location.href='" + Url.Action("Index") + "'</script>");

        }
        [HttpGet]
        public ActionResult Yuntiku()
        {
            return PartialView("YTK");
        }
        /// <summary>
        /// 云题库上传
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Yuntiku(string x)
        {
            YTK ytk = new YTK();
            var files = Request.Files;
            var studentNo = Convert.ToInt32(this.User.Identity.Name);
            string fileName = studentNo + "/" + studentNo + "-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "/";
            if (files != null && files.Count > 0)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    var strs = files[i].FileName.Split('.');
                    ytk.uploadFilePath = "~/WorkSpances/YTK/" + fileName + "/";
                    var path = Server.MapPath(ytk.uploadFilePath);
                    //如果路径不存在则创建
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    ytk.studentNo  = studentNo;

                    string uploadFileName =Guid.NewGuid().ToString() + "." + strs[1].ToLower();
                    ytk.uploadFileName = uploadFileName;
                    ytk.Describeyt = "无";
                    files[i].SaveAs(path + uploadFileName);
                }
                student.AddYTK(ytk);
            }
            return Content("<script>alert('上传完成!');</script>");
        }
        /// <summary>
        /// 预习总结上传
        /// </summary>
        /// <param name="yx"></param>
        /// <param name="uploadFilelx"></param>
        /// <returns></returns>
        public ActionResult Yuxi(YuXi yx, HttpPostedFileBase uploadFileyx)
        {
            yx.HomeworkTypeId = 1;
            yx.StudentNo = Convert.ToInt32(this.User.Identity.Name);
            //设置文件名
            string fileName = yx.StudentNo + "/" + yx.StudentNo + "-" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Millisecond + ".zip";
            //文件保存路径
            string path = Server.MapPath("~/WorkSpances/YXZJ/" + yx.StudentNo + "/");
            //如果路径不存在则创建
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string uploadFilePath = "~/WorkSpances/YXZJ/" + fileName;
            string uploadFilePathRe = Server.MapPath(uploadFilePath);
            yx.UploadFileNameyx = fileName;
            uploadFileyx.SaveAs(uploadFilePathRe);
            yx.UploadFilePath = uploadFilePath;
            student.AddYuXi(yx);
            return Content("<script>alert('上传成功！');location.href='" + Url.Action("Index") + "'</script>");
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
