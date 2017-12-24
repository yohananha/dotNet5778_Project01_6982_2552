using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract
    {
        public int idContract { get; set; }
        public long idNanny { get; set; }
        public long idChild { get; set; }
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

        public Contract duplication()
        {
            Contract duplicationContract = new Contract();

            duplicationContract.idContract = this.idContract;
            duplicationContract.idNanny = this.idNanny;
            duplicationContract.idChild = this.idChild;
            duplicationContract.isMet = this.isMet;
            duplicationContract.isContract = this.isContract;
            duplicationContract.salaryPerHour = this.salaryPerHour;
            duplicationContract.salaryPerMonth = this.salaryPerMonth;
            duplicationContract.isHour = this.isHour;
            duplicationContract.workBegin = this.workBegin;
            duplicationContract.workEnd = this.workEnd;

            return duplicationContract;
        }
    }
}
