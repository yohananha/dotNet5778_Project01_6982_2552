using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BE
{
    public class Nanny
    {
        public long nannyId { get; set; }
        public string lastNameNanny { get; set; }
        public string firstNameNanny { get; set; }
        public DateTime dateNanny { get; set; }
        public long phoneNanny { get; set; }
        public string addressNanny { get; set; }
        public bool elevatorNanny { get; set; }
        public int floorNanny { get; set; }
        public int experienceNanny { get; set; }
        public int maxChildNanny { get; set; }
        public int minEgeChildNanny { get; set; }
        public int maxEgeChildNanny { get; set; }
        public bool isByHourNanny { get; set; }
        public int rateHourNanny { get; set; }
        public int rateMonthNanny { get; set; }
        public bool[] daysWorkNanny { get; set; }
        public DateTime[,] hoursWorkNanny { get; set; }
        public bool isTamatNanny { get; set; }
        public string recommendationsNanny { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
