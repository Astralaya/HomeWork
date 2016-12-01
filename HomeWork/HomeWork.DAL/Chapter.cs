using HomeWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.DAL
{
    public class Chapter
    {

        HomeWorkEntities context = new HomeWorkEntities();

        //通过SubjectId查找所有章节
        public List<HomeWork.Model.Chapter> getChapterBySubjectId(int? id)
        {

            if (id != null)
            {

                List<HomeWork.Model.Chapter> list = context.Chapters.Where(Chapters => Chapters.SubjectId == id).ToList();
                return list;
            }
            else
            {

                return null;
            }


        }

    }
}
