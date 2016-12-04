using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Model
{
    public class YuXi
    {
        public int StudentNo { get; set; }                          //学生学号
        //[DisplayName("书本")]
        //[Required(ErrorMessage = "请选择{0}")]
        //[Compare("", ErrorMessage = "请选择{0}")]
        public int SubjectIdyx { get; set; }                        //书本ID
        //[DisplayName("章节")]
        //[Required(ErrorMessage="请选择{0}")]
        //[Compare("",ErrorMessage="请选择{0}")]
        public Nullable<int> ChapterId { get; set; }              //章节ID
        public string UploadFileNameyx { get; set; }                //作业名称
        //[DisplayName("完成度")]
        //[Required(ErrorMessage = "请填写{0}")]
        //[Range(1,100,ErrorMessage="{0}必须是{1}~{2}以内的数字")]
        //[DisplayName("描述")]
        //[Required(ErrorMessage = "请填写{0}")]
        public string Describeyx { get; set; }                      //描述
        public string UploadFilePath { get; set; }                  //文件路径
        public int HomeworkTypeId { get; set; }                     //作业类型
        public string Z_Have { get; set; }                          //已掌握
        public string Z_NotHave { get; set; }                       //未掌握
        public string Y_Have { get; set; }                          //已预习
        public string Y_NotHave { get; set; }                       //未预习
    }
}
