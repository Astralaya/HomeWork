using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork.DAL;

namespace HomeWork.BLL
{
    public class Chapter
    {
        static DAL.Chapter chapter = new DAL.Chapter();

        public List<HomeWork.Model.Chapter> getChapterBySubjectId(int? id)
        {
            return chapter.getChapterBySubjectId(id);

        }



    }
}
