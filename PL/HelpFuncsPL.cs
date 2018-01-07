using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
     static class HelpFuncsPL
    {
        public static DateTime ToTime(this DateTime DT)
        {
            return DT.ToUniversalTime().AddHours(2);
        }
    }
}
