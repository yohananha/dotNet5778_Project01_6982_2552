﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class Child
    {
        public int idMom { get; set; }
        public int idChild { get; set; }
        public string firstName { get; set; }
        public DateTime birthdayKid { get; set; }
        public bool isSpecialNeed { get; set; }
        public string specialNeeds { get; set; }

        public override string ToString()
        {
            return base.ToString(); 
        }
    }
}
