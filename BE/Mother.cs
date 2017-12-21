using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace BE
{
    public class Mother
    {
        public long idMom { get; set; }
        public string LasNameMom { get; set; }
        public string FirstNameMom { get; set; }
        public int PhoneMom { get; set; }
        public string AddressMom { get; set; }
        public bool IsLookingForNanny { get; set; }
        public bool[] DaysRequestMom { get; set; }
        public DateTime[,] HoursRequestMom { get; set; }


        public override string ToString()
        {
            throw new System.NotImplementedException();
        }
    }
}