using HomeWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HomeWork.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginUser lu)
        {

            if (ModelState.IsValid)
            {
                //学生登录
                if (lu.Type == 1)
                {
                    var user = BLL.Student.existUser(lu);
                    if (user == null)
                    {
                        error(user);
                        return View(lu);
                    }
                    FormsAuthentication.SetAuthCookie(user.StudentNo.ToString(), false);
                    return RedirectToAction("Index", "Student");
                }

                //教员登录
                if (lu.Type == 2)
                {
                    var user = BLL.Teacher.existUser(lu);
                    if (user == null)
                    {
                        error(user);
                        return View(lu);
                    }
                    FormsAuthentication.SetAuthCookie(user.TeacherNo.ToString(), false);
                    return RedirectToAction("Index", "Teacher");
                }
                //管理员登录
                if (lu.Type == 3)
                {
                    var user = BLL.Admin.existUser(lu);
                    if (user == null)
                    {
                        error(user);
                        return View(lu);
                    }
                    FormsAuthentication.SetAuthCookie(user.AdminId.ToString(), false);
                    return RedirectToAction("Index", "Admin/Home");
                }


            }
            return View("Login");
        }

        private void error(dynamic user)
        {
            ModelState.AddModelError("", "用户名或密码不正确！！");
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }


        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult SecurityCode()
        {
            string code = tool.IdentityCode.CreateRandomCode(5);
            TempData["SecurityCode"] = code;
            return File(tool.IdentityCode.CreateValidateGraphic(code), "image/Jpeg");
        }
    }
}
