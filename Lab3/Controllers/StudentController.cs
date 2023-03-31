using StudentDeptMemoCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using StudentDeptMemoCRUD.Service;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentDeptMemoCRUD.Controllers
{
    public class StudentController : Controller
    {
        
        private IStudent Db;

        public StudentController(IStudent db)
        {
            Db = db;
        }

        public IActionResult Index()
        {
            
            return View(Db.GettAllStudents());
        }

        [HttpPost]
        public IActionResult Create(Student? std)
        {
            if (ModelState.IsValid)
            {
                Db.AddStudent(std);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Departments = new SelectList(Db.GetAllDepartments(), "Id", "Name");
                return View(std);
            }
        }

        [HttpGet]
        public IActionResult Create(int id) 
        {
            ViewBag.Departments = new SelectList(Db.GetAllDepartments(),"Id","Name");
            return View();
        }

        public IActionResult Details(int? Id)
        {
            if(Id is null)
                return BadRequest();
            Student? std = Db.GetStudentById(Id.Value);
            if(std is null)
                return NotFound();
            else
                return View(std);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Departments = new SelectList(Db.GetAllDepartments(), "Id", "Name");
            return View(Db.GettAllStudents().FirstOrDefault(std => std.Id == id));
        }

        [HttpPost]
        public IActionResult Edit(Student newStd)
        {
            if (ModelState.IsValid)
            {
                Db.UpdateStudent(newStd);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Departments = new SelectList(Db.GetAllDepartments(), "Id", "Name");
                return View(newStd);
            }
        }

        public IActionResult Delete(int id)
        {
            Db.DeleteStudent(id);
            return RedirectToAction("index");
        }


    }
}
