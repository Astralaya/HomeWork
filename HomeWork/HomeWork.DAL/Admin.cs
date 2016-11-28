using HomeWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.DAL
{
    /// <summary>
    /// 后台
    /// </summary>
    public class Admin
    {
        HomeWorkEntities context = new HomeWorkEntities();
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="al"></param>
        /// <returns></returns>
        public Administrator existUser(LoginUser al)
        {
            return context.Administrators.SingleOrDefault(a => a.AdminName == al.UserName && a.Password == al.Password);
        }
        /// <summary>
        /// 查询文件上传设置
        /// </summary>
        /// <returns></returns>
        public List<UploadFile> executeQueryUpLoadFile()
        {
            
            return context.UploadFiles.Select(f =>f).ToList();
        }

        /// <summary>
        /// 增、删、改文件上传设置
        /// </summary>
        /// <param name="uf"></param>
        /// <returns></returns>
        public int executeUpdateUpLoadFile(UploadFile uf)
        {
            //context.UploadFiles.Add(uf
            return 0;
        }
    }
}
