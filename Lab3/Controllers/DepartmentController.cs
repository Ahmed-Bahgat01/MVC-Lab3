using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentDeptMemoCRUD.Models;
using StudentDeptMemoCRUD.Service;

namespace StudentDeptMemoCRUD.Controllers
{
    public class DepartmentController : Controller
    {
        private IUnitOfWork Db;

        public DepartmentController(IUnitOfWork _Db)
        {
            Db= _Db;
        }
        public IActionResult Index()
        {
            return View(Db.Departments.GetAll());
        }
        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();
            Department? requestedDept = Db.Departments.GetById(id.Value);
            if(requestedDept is null)
                return NotFound();
            return View(requestedDept);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department? newDept)
        {
            if (ModelState.IsValid)
            {
                Db.Departments.Add(newDept);
                Db.Save();
                return RedirectToAction("Index");
            }
            else
                return View(newDept);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(Db.Departments.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(Department? newDept) 
        {
            if(ModelState.IsValid)
            {
                Db.Departments.Update(newDept);
                Db.Save();
                return RedirectToAction("Index");
            }
            else return View(newDept);
            
        }

        public IActionResult Delete(int id)
        {
            Department? toBeRemoved = Db.Departments.GetById(id);
            Db.Departments.Remove(toBeRemoved);
            Db.Save();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateCourses(int id)
        {
            Department targetDept = Db.Departments.GetById(id);
            List<Course> allCourses = Db.Courses.GetAll().ToList();
            List<Course> coursesInDept = targetDept.Courses.ToList();
            List<Course> coursesNotInDept = allCourses.Except(coursesInDept).ToList();
            ViewBag.coursesInDept = new SelectList(coursesInDept, "Id", "Name");
            ViewBag.coursesNotInDept = new SelectList(coursesNotInDept, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult UpdateCourses(int id,int[] coursesToRemove,int[] coursesToAdd)
        {
            Department targetDept = Db.Departments.GetById(id);
            foreach (var courseId in coursesToRemove)
            {
                targetDept.Courses.Remove(Db.Courses.GetById(courseId));
            }
            foreach (var courseId in coursesToAdd)
            {
                targetDept.Courses.Add(Db.Courses.GetById(courseId));
            }
            Db.Save();
            return RedirectToAction("Index");
        }

        public IActionResult ShowCourses(int id)
        {
            Department targetDept = Db.Departments.GetById(id);
            return View(targetDept);
        }

        //public IActionResult EditStudentsGrades(int deptId, int courseId)
        //{
        //    Department targetDept = Db.Departments.GetById(deptId);
        //    Course targetCourse = targetDept.Courses.FirstOrDefault(a => a.Id == courseId);
        //    //List<Student> studentsInCourse = targetCourse.stude

        //}

    }
}
