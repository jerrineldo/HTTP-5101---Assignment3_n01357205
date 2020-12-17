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

        /// <summary>
        /// Receives a request to show the details of the teacher to be updated
        /// </summary>
        /// <param name="Id">Id of the  teacher to be updated </param>
        /// <returns>A dynamic web page to show the details of the teacher to be updated</returns>
        /// <example>//GET /Teacher/Update/2</example>
        [HttpGet]
        public ActionResult Update(int Id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher TeacherInfo = controller.FindTeacher(Id);
            return View(TeacherInfo);
        }

        /// <summary>
        /// Receives a POST request containing information about an existing teacher in the system,with new values.
        /// Conveys this information to the API, and redirects to the "Teacher Show" page of our updated Teacher.
        /// </summary>
        /// <param name="Id">Id of the Teacher to be updated</param>
        /// <param name="TeacherFname">The updated First name of the Teacher</param>
        /// <param name="TeacherLname">The updated Last name of the Teacher</param>
        /// <param name="EmployeeNumber">The Employee Number of the Teacher</param>
        /// <param name="Salary">The Salary of the Teacher</param>
        /// <returns>A Dynamic Web page which provides the current information of the Teacher</returns>
        /// <example>
        /// POST :/Teacher/Update/10
        /// FORM DATA 
        /// {
        /// "AuthorFname":"Jerrin",
        /// "AuthorLname":"Eldo",
        /// "AuthorBio"  :"Loves Football",
        /// "AuthorEmail :"jerrin@test.ca"
        /// }
        /// </example>
        [HttpPost]
        public ActionResult Update(int Id, string TeacherFname, string TeacherLname, string EmployeeNumber, double Salary)
        {
            Teacher UpdatedTeacherInfo = new Teacher();
            UpdatedTeacherInfo.TeacherFname = TeacherFname;
            UpdatedTeacherInfo.TeacherLname = TeacherLname;
            UpdatedTeacherInfo.EmployeeNumber = EmployeeNumber;
            UpdatedTeacherInfo.Salary = Salary;

            TeacherDataController controller = new TeacherDataController();
            controller.UpdateTeacher(Id, UpdatedTeacherInfo);
            return RedirectToAction("Show/" + Id);
        }

    }
}