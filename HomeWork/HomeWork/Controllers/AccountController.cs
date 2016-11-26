using HomeWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
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
