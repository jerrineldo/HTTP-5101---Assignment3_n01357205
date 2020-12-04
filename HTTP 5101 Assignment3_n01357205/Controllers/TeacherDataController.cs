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

        //This Controller Will access the teachers table of our school database with a SearchKey present in their names
        /// <summary>
        /// Returns a list of teachers in the system with the SearchKey present in their names
        /// </summary>
        /// <example>GET api/TeacherData/ListTeachers?SearchKey=e</example>
        /// <returns>
        /// A list of <Teacher>Teachers with the SearchKey present in their names
        /// </returns>
        [HttpGet]
        public IEnumerable<Teacher> ListTeachers(string SearchKey=null)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from teachers where LOWER(teacherfname) like lower(@key) " +
                               "OR LOWER(teacherlname) like LOWER(@key) OR LOWER" +
                               "(CONCAT(teacherfname,' ', teacherlname)) LIKE LOWER(@key)";

            //Preventing SQL Injection Attack
            cmd.Parameters.AddWithValue("@key", "%" + SearchKey + "%");
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Create an empty list of Teachers
            List<Teacher> Teachers = new List<Teacher> { };

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                Teacher NewTeacher = new Teacher();

                //Access Column information by the DB column name as an index

                NewTeacher.TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                NewTeacher.TeacherFname = ResultSet["teacherfname"].ToString();
                NewTeacher.TeacherLname = ResultSet["teacherlname"].ToString();
                NewTeacher.EmployeeNumber = ResultSet["employeenumber"].ToString();
                NewTeacher.HireDate = Convert.ToDateTime(ResultSet["hiredate"]);
                NewTeacher.Salary = Convert.ToDouble(ResultSet["salary"]);

                //Add the Teacher Name to the List
                Teachers.Add(NewTeacher);
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
        /// <param name="id">Teacher Id to match against a primary key record in the MySQL Database</param>
        /// <returns>Returns a Teacher Object</returns>
        [HttpGet]
        public Teacher FindTeacher(int id)
        {
            Teacher NewTeacher = new Teacher();

            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Select * from Teachers where teacherid = @key";

            //Preventing SQL Injection Attack
            cmd.Parameters.AddWithValue("@key", id);
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //Loop Through Each Row the Result Set
            while (ResultSet.Read())
            {
                //Access Column information by the DB column name as an index

                NewTeacher.TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                NewTeacher.TeacherFname = ResultSet["teacherfname"].ToString();
                NewTeacher.TeacherLname = ResultSet["teacherlname"].ToString();
                NewTeacher.EmployeeNumber = ResultSet["employeenumber"].ToString();
                NewTeacher.HireDate = Convert.ToDateTime(ResultSet["hiredate"]);
                NewTeacher.Salary = Convert.ToDouble(ResultSet["salary"]);
            }
            return NewTeacher;
        }

        /// <summary>
        /// Function to delete a Teacher based on a teacherId provided
        /// </summary>
        /// <example>POST : api/TeacherData/DeleteTeacher/8</example>
        /// <param name="id">Id of Teacher to be deleted</param>
        /// <returns>Does not return anything.</returns>
        [HttpPost]
        public void DeleteTeacher(int id)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Delete from teachers where teacherid=@id";

            //Preventing SQL Injection Attack
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            cmd.ExecuteReader();

            Conn.Close();
        }

        /// <summary>
        /// Function to create a new Teacher 
        /// </summary>
        /// <example>POST : api/TeacherData/CreateTeacher
        /// FORM DATA / POST DATA / REQUEST BODY 
        /// {
        ///	"TeacherFname":"Christine",
        ///	"TeacherLname":"Bittle",
        ///	"TeacherEmployeeNumber":"T254",
        ///	"TeacherSalary": 75
        /// }
        /// </example>
        /// <param name = "NewTeacher">An object with fields that map to the columns of the teacher's table.</param>
        /// <returns>Does not return anything.</returns>
        [HttpPost]
        public void CreateTeacher(Teacher NewTeacher)
        {
            //Create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            //Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //SQL QUERY
            cmd.CommandText = "Insert into teachers(teacherfname,teacherlname,employeenumber," +
                "hiredate,salary) values(@TeacherFname,@TeacherLname,@EmployeeNumber,@HireDate,@Salary)";

            //Preventing SQL Injection Attack
            cmd.Parameters.AddWithValue("@TeacherFname", NewTeacher.TeacherFname);
            cmd.Parameters.AddWithValue("@TeacherLname", NewTeacher.TeacherLname);
            cmd.Parameters.AddWithValue("@EmployeeNumber", NewTeacher.EmployeeNumber);
            cmd.Parameters.AddWithValue("@HireDate", NewTeacher.HireDate);
            cmd.Parameters.AddWithValue("@Salary", NewTeacher.Salary);
            cmd.Prepare();

            //Gather Result Set of Query into a variable
            cmd.ExecuteReader();

            Conn.Close();
        }
    }
}
