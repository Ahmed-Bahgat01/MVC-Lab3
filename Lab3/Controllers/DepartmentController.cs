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
            Department? targetDept = Db.Departments.GetById(id);
            List<Course> allCourses = Db.Courses.GetAll().ToList();
            if(targetDept is not null)
            {
                List<Course> coursesInDept = targetDept.Courses.ToList();
                List<Course> coursesNotInDept = allCourses.Except(coursesInDept).ToList();
                ViewBag.coursesInDept = new SelectList(coursesInDept, "Id", "Name");
                ViewBag.coursesNotInDept = new SelectList(coursesNotInDept, "Id", "Name");
                return View();
            }
            else
            {
                return NotFound();
            }
            
        }

        [HttpPost]
        public IActionResult UpdateCourses(int id,int[] coursesToRemove,int[] coursesToAdd)
        {
            if (ModelState.IsValid)
            {
                Department? targetDept = Db.Departments.GetById(id);
                if (targetDept is not null)
                {
                    Course? pointerCourse;
                    foreach (var courseId in coursesToRemove)
                    {
                        pointerCourse = Db.Courses.GetById(courseId);
                        if (pointerCourse is not null)
                            targetDept.Courses.Remove(pointerCourse);
                    }
                    foreach (var courseId in coursesToAdd)
                    {
                        pointerCourse = Db.Courses.GetById(courseId);
                        if (pointerCourse is not null)
                            targetDept.Courses.Add(pointerCourse);
                    }
                    Db.Save();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return View();
            }
            
        }

        public IActionResult ShowCourses(int id)
        {
            Department? targetDept = Db.Departments.GetById(id);
            if(targetDept is not null)
                return View(targetDept);
            else
                return NotFound();
        }

        public IActionResult EditStudentsGrades(int deptId, int courseId)
        {
            List<StudentCourse> courseStudentsGradesInDepartment = Db.StudentCourses.GetAll()
                .Where(a=>a.CourseId == courseId && a.Student?.DepartmentId == deptId)
                .ToList();
            return View(courseStudentsGradesInDepartment);
        }

        [HttpPost]
        public IActionResult EditStudentsGrades(int deptId, int courseId, Dictionary<int, int> stdGrade)
        {
            if (ModelState.IsValid)
            {
                StudentCourse? targetStudentCourse;
                foreach (var item in stdGrade)
                {
                    targetStudentCourse = Db.StudentCourses.GetById(item.Key, courseId);
                    if (targetStudentCourse is not null)
                    {
                        targetStudentCourse.Grade = item.Value;
                    }
                }
                Db.Save();
                return RedirectToAction(nameof(ShowCourses), new { id = deptId });
            }
            else 
            {
                List<StudentCourse> courseStudentsGradesInDepartment = Db.StudentCourses.GetAll()
                .Where(a => a.CourseId == courseId && a.Student?.DepartmentId == deptId)
                .ToList();
                return View(courseStudentsGradesInDepartment); 
            }
        }

    }
}
