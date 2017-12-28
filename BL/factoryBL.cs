using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;

namespace BL
{
    public class FactoryBL
    {
        public static Ibl bl = null;
        public static Ibl GetBL()
        {
            if (bl == null)
                bl = new BL_imp();
            return bl;
        }
    }

}

