using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DS
{
    class DataSource
    {
        public static List<Nanny> nannyList = new List<Nanny>();
        public static List<Mother> motherList = new List<Mother>();
        public static List<Child> childList = new List<Child>();
        public static List<Contract> contractList = new List<Contract>();

        //public static DataSource ds = null;

        //public static DataSource GetDs()
        //{
        //    if (ds == null)
        //        ds = new DataSource();
        //    return ds;
        //}

        //private DataSource()
        //{
        //    nannyList = new List<Nanny>();
        //    motherList = new List<Mother>();
        //    childList = new List<Child>();
        //    contractList = new List<Contract>();
        //}
    }
}
