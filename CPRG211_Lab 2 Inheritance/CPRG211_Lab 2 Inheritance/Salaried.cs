using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CPRG211_Lab_2_Inheritance
{
    internal class Salaried : Employee
    {

        //Constant

        //Fields

        private double salary;


        //Properties

        public double Salary
        {
            get { return salary; }
            set { salary = value; }

        }


        //Constructor
        public Salaried(string id, string name, string address, string phone, long sin, string dob, string dept, double salary) : base(id, name, address, phone, sin, dob, dept)
        {

            this.Salary = salary;
        }

        //Methods

        public double GetPay()
        {
            return salary;
        }

            // Method to display a list of salaried employee information.
        public override string ToString() {

            return $"The lowest salary pay is ${Salary:C} for salaried employee, {Name}.";

        }

    }
}
