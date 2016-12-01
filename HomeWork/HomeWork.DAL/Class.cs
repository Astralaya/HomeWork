using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork.Model;

namespace HomeWork.DAL
{
   public class Class
    {
       HomeWorkEntities context = new HomeWorkEntities();
       public List<HomeWork.Model.Class> getAllClass()
        {

            List<HomeWork.Model.Class> list = context.Classes.ToList();
            return list;


        }
    }
}
