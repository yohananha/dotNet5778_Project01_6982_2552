using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class factoryDal
    {
        private static Idal dal = null;

        public static Idal getDal()
        {
            if (dal == null)
                dal = new Dal_XML_imp();
            return dal;
        }
    }
}
