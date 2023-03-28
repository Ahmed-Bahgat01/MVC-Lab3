using Microsoft.AspNetCore.Mvc;
using StudentDeptMemoCRUD.Models;

namespace StudentDeptMemoCRUD.Controllers
{
    public class DepartmentController : Controller
    {
        private DepartmentMoc DeptMoc = new DepartmentMoc();
        public IActionResult Index()
        {
            return View(DeptMoc.Departments);
        }
        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();
            Department? requestedDept = DeptMoc.GetDepartmentById(id.Value);
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
                DeptMoc.AddDepartment(newDept);
                return RedirectToAction("Index");
            }
            else
                return View(newDept);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(DeptMoc.GetDepartmentById(id));
        }

        [HttpPost]
        public IActionResult Edit(Department? newDept) 
        {
            if(ModelState.IsValid)
            {
                DeptMoc.UpdateDepartment(newDept);
                return RedirectToAction("Index");
            }
            else return View(newDept);
            
        }

        public IActionResult Delete(int id)
        {
            DeptMoc.DeleteDepartment(id);
            return RedirectToAction("Index");
        }

    }
}
