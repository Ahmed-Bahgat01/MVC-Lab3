using Microsoft.AspNetCore.Mvc;
using StudentDeptMemoCRUD.Models;
using StudentDeptMemoCRUD.Service;

namespace StudentDeptMemoCRUD.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartment Db;

        public DepartmentController(IDepartment _Db)
        {
            Db= _Db;
        }
        public IActionResult Index()
        {
            return View(Db.GetAllDepartments());
        }
        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();
            Department? requestedDept = Db.GetDepartmentById(id.Value);
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
                Db.AddDepartment(newDept);
                return RedirectToAction("Index");
            }
            else
                return View(newDept);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(Db.GetDepartmentById(id));
        }

        [HttpPost]
        public IActionResult Edit(Department? newDept) 
        {
            if(ModelState.IsValid)
            {
                Db.UpdateDepartment(newDept);
                return RedirectToAction("Index");
            }
            else return View(newDept);
            
        }

        public IActionResult Delete(int id)
        {
            Db.DeleteDepartment(id);
            return RedirectToAction("Index");
        }

    }
}
