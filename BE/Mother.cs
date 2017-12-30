using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace BE
{
    public class Schedule
    {
        public DateTime startHour = DateTime.MinValue;
        public DateTime endHour = DateTime.MinValue;
    }
    public class Mother
    {
        public long IdMom { get; set; }
        public string LasNameMom { get; set; }
        public string FirstNameMom { get; set; }
        public int PhoneMom { get; set; }
        public string AddressMom { get; set; }
        public string AddressForNanny { get; set; }
        public bool[] DaysRequestMom { get; set; }
        public Schedule[] ScheduleMom { get; set; }
        public string nothMom { get; set; }

        public override string ToString()
        {
            throw new System.NotImplementedException();
        }

        public Mother duplication()
        {
            Mother duplicationMom = new Mother();

            duplicationMom.IdMom = this.IdMom;
            duplicationMom.LasNameMom = this.LasNameMom;
            duplicationMom.FirstNameMom = this.FirstNameMom;
            duplicationMom.PhoneMom = this.PhoneMom;
            duplicationMom.AddressMom = this.AddressMom;
            duplicationMom.AddressForNanny = this.AddressForNanny;
            duplicationMom.DaysRequestMom = this.DaysRequestMom;
            duplicationMom.ScheduleMom = this.ScheduleMom;
            duplicationMom.nothMom = this.nothMom;

            return duplicationMom;
        }
    }
}