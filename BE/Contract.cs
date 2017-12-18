using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class Contract
    {
        public int idContract { get; set; }
        public long idNanny { get; set; }
        public long idKid { get; set; }
        public bool isMet { get; set; }
        public bool isContract { get; set; }
        public double salaryPerHour { get; set; }
        public double salaryPerMonth { get; set; }
        public bool isHour { get; set; }
        public DateTime workBegin { get; set; }
        public DateTime workEnd { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
