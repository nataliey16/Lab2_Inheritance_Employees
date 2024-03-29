﻿using System.Data.Common;

namespace CPRG211_Lab_2_Inheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("employees.txt"); // Create an array called lines that reads each line in the employee.txt file


            //Add list of Employees

            List<Employee> employees = new List<Employee>();


            foreach (string line in lines) // For every line in lines (aka the employee text file)
            {

                //Console.WriteLine("Processing line: " + line); // Debugging line

                string[] columns = line.Split(':'); // we want to split the first column in each row

                string id = columns[0]; //create a string variable and assign it to the first column in employee.txt
                string name = columns[1];
                string address = columns[2];
                string phone = columns[3];
                string sin = columns[4];
                string dob = columns[5];
                string dept = columns[6];


                char firstDigitOfId = id[0]; // Recall a string is collection of chars (characters/letters). Convert variable to char because we only want 1 character, not an entire string 

                if (firstDigitOfId == '0' || firstDigitOfId == '1' || firstDigitOfId == '2' || firstDigitOfId == '3' || firstDigitOfId == '4') // If the first digit of ID is 0-4 = salaried employee
                {
                    if (columns.Length >= 8)
                    {
                        string salary = columns[7];

                        //Create a Salaried object
                        Salaried salariedEmp = new Salaried(id, name, address, phone, long.Parse(sin), dob, dept, double.Parse(salary));
                        employees.Add(salariedEmp); // Add the object to the List

                    }
                }
                else if (firstDigitOfId == '5' || firstDigitOfId == '6' || firstDigitOfId == '7')
                {
                    if (columns.Length >= 9)
                    {
                        string rate = columns[7];
                        string hours = columns[8];

                        //Created Wages Object
                        Wages wagesEmp = new Wages(id, name, address, phone, long.Parse(sin), dob, dept, double.Parse(rate), double.Parse(hours));
                        employees.Add(wagesEmp); // Add the object to the List 


                    }
                }
                else if (firstDigitOfId == '8' || firstDigitOfId == '9')
                {
                    if (columns.Length >=9) { 

                        string rate = columns[7];
                        string hours = columns[8];  

                        //Create Part-time Object

                        PartTime partTimeEmp = new PartTime(id, name, address, phone, long.Parse(sin), dob, dept, double.Parse(rate), double.Parse(hours));
                        employees.Add(partTimeEmp); // Add the object to the list


                    }
                }
            }



            // Calculate and return the average weekly pay for all employees.
            double totalWeeklyPay = 0.0;

            foreach(Employee employee in employees)
            {
                if (employee is Salaried salariedEmp)
                {
                    double eachEmpSalary = salariedEmp.GetPay();
                    totalWeeklyPay += eachEmpSalary; // Add each employee's salary to the total

                }

                if (employee is Wages wageEmp)
                {
                    double eachEmpWage = wageEmp.GetPay();
                    totalWeeklyPay += eachEmpWage;// Add each employee's salary to the total
                }

                if(employee is PartTime partTimeEmp)
                {
                    double eachEmpPartTimePay = partTimeEmp.GetPay();
                    totalWeeklyPay += eachEmpPartTimePay;// Add each employee's salary to the total
                }
            }

            double avgWeeklyPay = Math.Round(totalWeeklyPay / (employees.Count),2);

            Console.WriteLine($"The average weekly pay for all employees is ${avgWeeklyPay:C}.");



            // Calculate and return the highest weekly pay for the wage employees, including the name of the employee.
            double highestWagesPay = double.MinValue;
            string highestWagesEmpName = string.Empty;
            Wages highestWageEmployee = null;


            foreach (Employee employee in employees)
            {
                if (employee is Wages wagesEmp)
                {
                    double showWages = wagesEmp.GetPay();
                    if (showWages > highestWagesPay)
                    {
                        highestWagesPay = Math.Round(showWages,2);
                        highestWagesEmpName = wagesEmp.Name;
                        highestWageEmployee = wagesEmp;
                    }
                }
            }

            if (highestWageEmployee != null)
            {
                Console.WriteLine(highestWageEmployee.ToString()); // Call the ToString method
            }

            // Calculate and return the lowest salary for the salaried employees, including the name of the employee.

            double lowestSalariedPay = double.MaxValue;
            string lowestSalariedEmpName = string.Empty;
            Salaried lowestSalariedEmp = null;


            foreach (Employee employee in employees)
            {
                if (employee is Salaried salariedEmp)
                {
                    double showSalary = salariedEmp.GetPay();

                    if (showSalary < lowestSalariedPay)
                    {
                        lowestSalariedPay = Math.Round(showSalary);
                        lowestSalariedEmpName = salariedEmp.Name;
                        lowestSalariedEmp = salariedEmp;

                    }
                }
            }
            if (lowestSalariedEmp != null)
            {
                Console.WriteLine(lowestSalariedEmp.ToString()); // Call the ToString method
            }


            //Calculate the percentage of the company’s employees that fall into each employee category


            //Count the number of employees in each employee category
            double numOfSalariedEmp = employees.Count(e => e is Salaried);
            double numOfWagesEmp = employees.Count(e => e is Wages);
            double numOfPartTimeEmp = employees.Count(e => e is PartTime);
            double totalNumOfEmployees = employees.Count();

            // Find the percentage

            double percentOfSalariedEmp = Math.Round((numOfSalariedEmp / totalNumOfEmployees) * 100,1);
            double percentOfWagesEmp = Math.Round((numOfWagesEmp / totalNumOfEmployees) * 100,1);
            double percentOfPartTimeEmp = Math.Round((numOfPartTimeEmp/ totalNumOfEmployees) * 100,1);


            Console.WriteLine($"{percentOfSalariedEmp}% of the company's employees are Salaried Employees.");
            Console.WriteLine($"{percentOfWagesEmp}% of the company's employees are Wage Employees.");
            Console.WriteLine($"{percentOfPartTimeEmp}% of of the company's employees are Part Time employees."); 

            Console.ReadLine();
        }
    }
}


