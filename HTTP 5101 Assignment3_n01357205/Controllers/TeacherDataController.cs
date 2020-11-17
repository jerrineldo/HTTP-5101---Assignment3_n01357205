using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HTTP_5101_Assignment3_n01357205.Models;
using MySql.Data.MySqlClient ;

namespace HTTP_5101_Assignment3_n01357205.Controllers
{
    public class TeacherDataController : ApiController
    {
        // The database context class which allows us to access our MySQL Database.
        private SchoolDbContext School = new SchoolDbContext();

        //This Controller Will access the teachers table of our school database.
        /// <summary>
        /// Returns a list of teachers in the system
        /// </summary>
        /// <example>GET api/TeacherData/ListTeachers</example>
        /// <returns>
        /// A list of Teachers (teacher id's, first names, last names, employee numbers, hiredate and salary)
        /// </returns>
        [HttpGet]
        public IEnumerable<Teacher> ListTeachers()
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from teachers";

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Teachers
            List<Teacher> Teachers = new List<Teacher> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int teacherId = (int)ResultSet["teacherid"];
                string teacherFname = (string)ResultSet["teacherfname"];
                string teacherLName = (string)ResultSet["teacherlname"];
                string employeeNumber = (string)ResultSet["employeenumber"];
                string hireDate = ResultSet["hiredate"].ToString();
                string teacherSalary = ResultSet["salary"].ToString();

                Teacher newTeacher = new Teacher();
                newTeacher.teacherId = teacherId;
                newTeacher.teacherFname = teacherFname;
                newTeacher.teacherLname = teacherLName;
                newTeacher.employeeNumber = employeeNumber;
                newTeacher.hireDate = hireDate;
                newTeacher.teacherSalary = teacherSalary;
                //Add the Teacher Name to the List
                Teachers.Add(newTeacher);
            }

            //Close the connection between the MySQL Database and the WebServer
            Conn.Close();

            //Return the final list of Teachers
            return Teachers;
        }
        /// <summary>
        /// Function to get a single block of data from the Teachers table based on the teacher's Id.
        /// </summary>
        /// <example>GET api/TeacherData/FindTeacher/8</example>
        /// <param name="id">Teacher Id</param>
        /// <returns>TA single Teacher Object</returns>
        [HttpGet]
        public Teacher FindTeacher(int id)
        {
            Teacher newTeacher = new Teacher();

            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from Teachers where teacherid =" + id;

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int teacherId = (int)ResultSet["teacherid"];
                string teacherFname = (string)ResultSet["teacherfname"];
                string teacherLName = (string)ResultSet["teacherlname"];
                string employeeNumber = (string)ResultSet["employeenumber"];
                string hireDate = ResultSet["hiredate"].ToString();
                string teacherSalary = ResultSet["salary"].ToString();

                newTeacher.teacherId = teacherId;
                newTeacher.teacherFname = teacherFname;
                newTeacher.teacherLname = teacherLName;
                newTeacher.employeeNumber = employeeNumber;
                newTeacher.hireDate = hireDate;
                newTeacher.teacherSalary = teacherSalary;
            }
            return newTeacher;
        }

        /// <summary>
        /// Function to fetch the details of the teacher object from the database
        /// </summary>
        /// <param name="fname">Teacher First name</param>
        /// <param name="salary">Teacher's salary</param>
        /// <returns>Teacher Object</returns>
        public Teacher SearchTeacher(string fname, string salary)
        {
            Teacher newTeacher = new Teacher();

            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from Teachers where teacherfname ='" + fname+"'" +
                               "AND salary = "+salary;

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index
                int teacherId = (int)ResultSet["teacherid"];
                string teacherFname = (string)ResultSet["teacherfname"];
                string teacherLName = (string)ResultSet["teacherlname"];
                string employeeNumber = (string)ResultSet["employeenumber"];
                string hireDate = ResultSet["hiredate"].ToString();
                string teacherSalary = ResultSet["salary"].ToString();

                newTeacher.teacherId = teacherId;
                newTeacher.teacherFname = teacherFname;
                newTeacher.teacherLname = teacherLName;
                newTeacher.employeeNumber = employeeNumber;
                newTeacher.hireDate = hireDate;
                newTeacher.teacherSalary = teacherSalary;
            }
            return newTeacher;
        }
    }
}
