using StudentDeptMemoCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using StudentDeptMemoCRUD.Service;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentDeptMemoCRUD.Controllers
{
    public class StudentController : Controller
    {
        
        private IUnitOfWork Db;

        public StudentController(IUnitOfWork db)
        {
            Db = db;
        }

        public IActionResult Index()
        {
            List<Student> lst = Db.Students.GetAll().ToList();
            return View(lst);
        }

        [HttpPost]
        public IActionResult Create(Student? std)
        {
            if (ModelState.IsValid)
            {
                Db.Students.Add(std);
                Db.Save();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Departments = new SelectList(Db.Students.GetAllDepartments(), "Id", "Name");
                return View(std);
            }
        }

        [HttpGet]
        public IActionResult Create(/*int id*/) 
        {
            ViewBag.Departments = new SelectList(Db.Students.GetAllDepartments(),"Id","Name");
            return View();
        }

        public IActionResult Details(int? Id)
        {
            if(Id is null)
                return BadRequest();
            Student? std = Db.Students.GetById(Id.Value);
            if (std is null)
                return NotFound();
            else
                return View(std);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Departments = new SelectList(Db.Students.GetAllDepartments(), "Id", "Name");
            return View(Db.Students.GetAll().FirstOrDefault(std => std.Id == id));
        }

        [HttpPost]
        public IActionResult Edit(Student newStd)
        {
            if (ModelState.IsValid)
            {
                Db.Students.Update(newStd);
                Db.Save();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Departments = new SelectList(Db.Students.GetAllDepartments(), "Id", "Name");
                return View(newStd);
            }
        }

        public IActionResult Delete(int id)
        {
            Student? toBeRemoved = Db.Students.GetById(id);
            Db.Students.Remove(toBeRemoved);
            Db.Save();
            return RedirectToAction("index");
        }


    }
}
