using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTTP_5101_Assignment3_n01357205.Models;

namespace HTTP_5101_Assignment3_n01357205.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        // GET: Teacher/Index
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Function to find a teachers details based on 2 parameters - firstname , salary
        /// </summary>
        /// <example>GET api/Teacher/Search/{firstname}/{salary}</example>
        /// <param name="fname">FirstName of Teacher</param>
        /// <param name="salary">Salary of Teacher</param>
        /// <returns>Teacher Object</returns>
        public ActionResult Search(string fname, string salary)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.SearchTeacher(fname, salary);
            return View("Show", NewTeacher);
        }

        /// <summary>
        /// An action which allows you to route Teachers data fetched from the database
        /// to dynamic web pages
        /// </summary>
        /// <returns>
        /// A list of Teachers
        /// </returns>
        //GET : /Teacher/List
        public ActionResult List()
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers();
            return View(Teachers);
        }

        //GET :/Teacher/Show/{id}
        /// <summary>
        /// An action which allows you to route single block of teachers data to a dynamic web page
        /// </summary>
        /// <param name="id">Teacher's id</param>
        /// <returns> A single Teacher Object</returns>
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);
            return View(NewTeacher);
        }
    }
}