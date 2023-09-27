using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211_Lab_2_Inheritance
{
    internal class Employee
    {
        //Constant


        //Field

        private string id;
        private string name;
        private string address;
        private string phone;
        private long sin;
        private string dob;
        private string dept;


        //Properties

        public string Id
        {
            get { return id; }
            set { id = value; } 

        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Address
        {

            get { return address; }
            set { address = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public long Sin
        {
            get { return sin; }
            set { sin = value; }
        }

        public string Dob
        {
            get { return dept; }
            set { dob = value; }

        }

        public string Dept
        {

            get { return dept; }
            set {  dept = value; }
        }



        //Constructors

        public Employee(string id, string name, string address, string phone, long sin, string dob, string dept) // Initialize all the class data
        {
            this.Id = id; // Add the this. to make it explicit - avoid shadowing 
            this.Name = name;
            this.Address = address;
            this.Phone = phone;
            this.Sin = sin;
            this.Dob = dob;
            this.Dept = dept;
        }


        //Methods

        public override string ToString()
        {
            string employeeInfo = $"{id} {name} {address} {phone} {sin} {dob} {dept}";

            return employeeInfo;
        }

    }
}
