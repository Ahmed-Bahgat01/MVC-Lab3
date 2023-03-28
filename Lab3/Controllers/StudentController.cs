using StudentDeptMemoCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace StudentDeptMemoCRUD.Controllers
{
    public class StudentController : Controller
    {
        
        StudentMoc stdMoc = new StudentMoc();
        public IActionResult Index()
        {
            
            return View(stdMoc.StudentsList);
        }

        [HttpPost]
        public IActionResult Create(Student std)
        {
            if (ModelState.IsValid)
            {
                stdMoc.AddStudent(std);
                return RedirectToAction("Index");
            }
            else
                return View(std);
        }

        [HttpGet]
        public IActionResult Create(int id) 
        { 
            return View();
        }

        public IActionResult Details(int? Id)
        {
            if(Id is null)
                return BadRequest();
            Student? std = stdMoc.GetStudentById(Id.Value);
            if(std is null)
                return NotFound();
            else
                return View(std);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(stdMoc.StudentsList.FirstOrDefault(std => std.Id == id));
        }

        [HttpPost]
        public IActionResult Edit(Student newStd)
        {
            if (ModelState.IsValid)
            {
                stdMoc.UpdateStudent(newStd);
                return RedirectToAction("Index");
            }
            else
                return View(newStd);
        }

        public IActionResult Delete(int id)
        {
            stdMoc.DeleteStudent(id);
            return RedirectToAction("index");
        }


    }
}
