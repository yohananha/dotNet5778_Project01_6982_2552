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
        public int minAgeChildNanny { get; set; }
        public int maxAgeChildNanny { get; set; }
        public bool isByHourNanny { get; set; }
        public int rateHourNanny { get; set; }
        public int rateMonthNanny { get; set; }
        public bool[] daysWorkNanny { get; set; }
        public bool isTamatNanny { get; set; }
        public string recommendationsNanny { get; set; }
        public int currentChildren { get; set; }
        public DateTime[] startHour { get; set; }
        public DateTime[] endHour { get; set; }
        public double diff { get; set; }
        public int Distance { get; set; }

        //public override string ToString()
        //{
        //    return base.ToString();
        //}

        public Nanny duplication()
        {
            Nanny duplicationNanny = new Nanny();

            duplicationNanny.nannyId = this.nannyId;
            duplicationNanny.firstNameNanny = this.firstNameNanny;
            duplicationNanny.lastNameNanny = this.lastNameNanny;
            duplicationNanny.dateNanny = this.dateNanny;
            duplicationNanny.phoneNanny = this.phoneNanny;
            duplicationNanny.addressNanny = this.addressNanny;
            duplicationNanny.elevatorNanny = this.elevatorNanny;
            duplicationNanny.floorNanny = this.floorNanny;
            duplicationNanny.experienceNanny = this.experienceNanny;
            duplicationNanny.maxChildNanny = this.maxChildNanny;
            duplicationNanny.minAgeChildNanny = this.minAgeChildNanny;
            duplicationNanny.maxAgeChildNanny = this.maxAgeChildNanny;
            duplicationNanny.isByHourNanny = this.isByHourNanny;
            duplicationNanny.rateHourNanny = this.rateHourNanny;
            duplicationNanny.rateMonthNanny = this.rateMonthNanny;
            duplicationNanny.daysWorkNanny = this.daysWorkNanny;
            duplicationNanny.isTamatNanny = this.isTamatNanny;
            duplicationNanny.recommendationsNanny = this.recommendationsNanny;
            duplicationNanny.currentChildren = this.currentChildren;
            duplicationNanny.startHour = this.startHour;
            duplicationNanny.endHour = this.endHour;
            duplicationNanny.diff = this.diff;
            duplicationNanny.Distance = this.Distance;

            return duplicationNanny;
        }
    }
}
