using Microsoft.AspNetCore.Mvc;
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

    }
}
