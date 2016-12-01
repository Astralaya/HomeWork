using HomeWork.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.BLL
{
    public class Class
    {
        DAL.Class c = new DAL.Class();
        public List<HomeWork.Model.Class> getAllClass()
        {

           
            return c.getAllClass();


        }


    }
}
