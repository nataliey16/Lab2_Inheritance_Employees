using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211_Lab_2_Inheritance
{
    internal class Wages : Employee
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

        //Constructor

        public Wages(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : base(id, name, address, phone, sin, dob, dept)
        {

            this.Rate = rate;
            this.Hours = hours;
        }


        //Methods

        public double GetPay()
        {

            double regularHours = Math.Min(40, hours); //Returns the smaller of the two numbers
            double overtimeHours = Math.Max(0, hours - 40); // Returns the larger of the two numbers 
            double regularWagePay = regularHours * rate;
            double overtimeWagePay = regularWagePay + (overtimeHours * (rate * 1.5));
            double wagesPay = 0.0; 

            if (hours <= 40)
            {
                wagesPay = regularWagePay;
            }
            else if (hours > 40)
            {
                wagesPay = overtimeWagePay;
            }

            return wagesPay;
        }


        public override string ToString()
        {
            string wagesEmpInfo = "Wage Employee: " + base.ToString() + " " + rate + " " + hours;
            return wagesEmpInfo;
        }



    }
}
