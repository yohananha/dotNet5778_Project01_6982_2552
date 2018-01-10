﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public long PhoneMom { get; set; }
        public string AddressMom { get; set; }
        public string AddressForNanny { get; set; }
        public bool[] DaysRequestMom { get; set; }
        public DateTime[] startHour { get; set; }
        public DateTime[] endHour { get; set; }
        public string nothMom { get; set; }

        public string fullName { get { return FirstNameMom + " " + LasNameMom; } }
        //public override string ToString()
        //{
        //    throw new System.NotImplementedException();
        //}

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
            duplicationMom.nothMom = this.nothMom;
            duplicationMom.endHour = this.endHour;
            duplicationMom.startHour = this.startHour;

            return duplicationMom;
        }
    }
}