using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace HTTP_5101_Assignment3_n01357205.Models
{
    public class Teacher
    {
        //The following fields define a Teacher
        public int TeacherId;
        public string TeacherFname;
        public string TeacherLname;
        public string EmployeeNumber;
        public DateTime HireDate;
        public double Salary;

        //Server Side Validation to check if the values retrieved from the database are valid.
        public bool IsValid()
        {
            bool valid = true;

            if (TeacherFname == null || TeacherLname == null || EmployeeNumber == null || Salary == 0 )
            {
                //Base validation to check if the fields are entered.
                valid = false;
            }
            else
            {
                //Validation for fields to make sure they meet server constraints
                if (TeacherFname.Length < 2 || TeacherFname.Length > 255) valid = false;
                if (TeacherLname.Length < 2 || TeacherLname.Length > 255) valid = false;
            }

            Debug.WriteLine("The model validity is : " + valid);

            return valid;
        }
    }
}