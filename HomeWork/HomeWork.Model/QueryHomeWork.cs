using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Model
{
   public class QueryHomeWork
    {
       public string StudentName { get; set; }  //学生姓名
       public Nullable<int> Speed { get; set; } //完成度
       public string Comment { get; set; }      //评价
       public string ScoreName { get; set; }      //评分
       public string UploadFilePath { get; set; }   //文件
       public System.DateTime UploadTime { get; set; }  //上传时间
       public string Describe { get; set; }     //文件描述
       public string UploadFileName { get; set; }   //文件名
       public string ChapterName { get; set; }//章节
    }
}
