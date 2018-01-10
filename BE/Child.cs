using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Child
    {
        public long idMom { get; set; }
        public long idChild { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthdayKid { get; set; }
        public bool isSpecialNeed { get; set; }
        public string specialNeeds { get; set; }

        public string fullName { get { return firstName + " " + lastName;  } }
        //public override string ToString()
        //{
        //    return base.ToString();
        //}

        public Child duplication()
        {
            Child duplicationChild = new Child();

            duplicationChild.idMom = this.idMom;
            duplicationChild.idChild = this.idChild;
            duplicationChild.firstName = this.firstName;
            duplicationChild.lastName = this.lastName;
            duplicationChild.birthdayKid = this.birthdayKid;
            duplicationChild.isSpecialNeed = this.isSpecialNeed;
            duplicationChild.specialNeeds = this.specialNeeds;

            return duplicationChild;
        }
    }
}
