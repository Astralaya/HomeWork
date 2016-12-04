using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HomeWork.Model
{
    public class LianXi
    {
        public int StudentNo { get; set; }                      //学生学号
        //[DisplayName("书本")]
        //[Required(ErrorMessage = "请选择{0}")]
        //[Compare("", ErrorMessage = "请选择{0}")]
        public int SubjectIdlx { get; set; }                      //书本ID
        //[DisplayName("章节")]
        //[Required(ErrorMessage="请选择{0}")]
        //[Compare("",ErrorMessage="请选择{0}")]
        public Nullable<int> ChapterId { get; set; }            //章节ID
        public string UploadFileNamelx { get; set; }              //作业名称
        //[DisplayName("完成度")]
        //[Required(ErrorMessage = "请填写{0}")]
        //[Range(1,100,ErrorMessage="{0}必须是{1}~{2}以内的数字")]
        public Nullable<int> Speedlx { get; set; }                //完成度
        //[DisplayName("描述")]
        //[Required(ErrorMessage = "请填写{0}")]
        public string Describelx { get; set; }                    //描述
        public string UploadFilePath { get; set; }              //文件路径
        public int HomeworkTypeId { get; set; }                 //作业类型
    }
}
