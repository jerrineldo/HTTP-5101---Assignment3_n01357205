using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTTP_5101_Assignment3_n01357205.Models;
using System.Diagnostics;

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
        /// An action which allows you to route Teachers data fetched from the database
        /// to dynamic web pages
        /// </summary>
        /// <returns>
        /// A list of Teachers
        /// </returns>
        //GET : /Teacher/List/{}
        public ActionResult List(string SearchKey = null)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(SearchKey);
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

        //GET : /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);

            return View(NewTeacher);
        }

        //POST :/Teacher/Delete/{id}
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }


        //GET: /Teacher/New
        public ActionResult Add()
        {
            return View();
        }

        //POST: /Author/Create
        [HttpPost]
        public ActionResult Create(string TeacherFname, string TeacherLname, string EmployeeNumber, double Salary)
        {
            Teacher NewTeacher = new Teacher();

            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname = TeacherLname;
            NewTeacher.EmployeeNumber = EmployeeNumber;
            NewTeacher.Salary = Salary;
            NewTeacher.HireDate = DateTime.Today;
            TeacherDataController controller = new TeacherDataController();
            controller.CreateTeacher(NewTeacher);
            return RedirectToAction("List");
        }

    }
}