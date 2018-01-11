using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract: INotifyPropertyChanged
    {
        public int idContract { get; set; }
        public string nameChild { get; set; }
        public string nameNanny { get; set; }
        private long _idNanny;
        public long idNanny  
        {
            get { return _idNanny; }
            set
            {
                _idNanny = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("idNanny"));
                }
            }
        }
        private long _idChild;
        public long idChild
        {
            get { return _idChild; }
            set
            {
                _idChild = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("idChild"));
                }
            }
        }
        public bool isMet { get; set; }
        public bool isContract { get; set; }
        private double _salaryPerHour;
        public double salaryPerHour
        {
            get { return _salaryPerHour; }
            set
            {
                _salaryPerHour = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("salaryPerHour"));
                }
            }
        }
        private double _salaryPerMonth;
        public double salaryPerMonth
        {
            get { return _salaryPerMonth; }
            set
            {
                _salaryPerMonth = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("salaryPerMonth"));
                }
            }
        }
        private double _salaryAgreed;
        public double salaryAgreed
        {
            get { return _salaryAgreed; }
            set
            {
                _salaryAgreed = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("salaryAgreed"));
                }
            }
        }
        private bool _isHour;
        public bool isHour
        {
            get { return _isHour; }
            set
            {
                _isHour = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("isHour"));
                }
            }
        }
        public DateTime workBegin { get; set; }
        public DateTime workEnd { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        //public override string ToString()
        //{
        //    return base.ToString();
        //}

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
            duplicationContract.nameChild = this.nameChild;
            duplicationContract.nameNanny = this.nameNanny;
            duplicationContract.salaryAgreed = this.salaryAgreed;

            return duplicationContract;
        }
    }
}
