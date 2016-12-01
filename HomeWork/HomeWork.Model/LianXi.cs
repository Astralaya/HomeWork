using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Model
{
    public class LianXi
    {
        public int StudentNo { get; set; }                      //学生学号
        public int SubjectIdlx { get; set; }                      //书本ID
        public Nullable<int> ChapterIdlx { get; set; }            //章节ID
        public string UploadFileNamelx { get; set; }              //作业名称
        public Nullable<int> Speedlx { get; set; }                //完成度
        public string Describelx { get; set; }                    //描述
        public string UploadFilePath { get; set; }              //文件路径
    }
}
