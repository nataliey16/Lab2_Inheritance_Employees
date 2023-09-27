using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211_Lab_2_Inheritance
{
    internal class PartTime:Employee
    {

        //Constant

        //Field

        private double rate;
        private double hours;


        //Properties

        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public double Hours
        {
            get { return hours; }
            set { hours = value; }
        }

        //Constructors

        public PartTime(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : base(id, name, address, phone, sin, dob, dept)
        {

            this.Rate = rate;
            this.Hours = hours;

        }

        //Methods

        public double GetPay() { 

            double partTimePay = rate * hours;
            return partTimePay;
        
        }

        public override string ToString()
        {
            string partTimeEmpInfo = "Part Time Employee: " + base.ToString() + " " + rate + " " + hours;

            return partTimeEmpInfo;

        }
    }
}
