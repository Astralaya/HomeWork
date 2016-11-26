using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeWork.Model
{
    public class LoginUser
    {
        [DisplayName("用户名")]
        [Required(ErrorMessage="请输入{0}!")]
        public string UserName { get; set; }
        [DisplayName("密码")]
        [Required(ErrorMessage = "请输入{0}!")]
        public string Password { get; set; }
        [DisplayName("身份类型")]
        [Required(ErrorMessage = "请选择{0}!")]
        public int Type { get; set; }
        [DisplayName("验证码")]
        [Required(ErrorMessage = "请输入{0}!")]
        public string IdentityCode { get; set; }
    }
}
