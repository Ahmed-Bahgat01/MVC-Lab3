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
            if(newDept is null)
                return BadRequest();
            DeptMoc.AddDepartment(newDept);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(DeptMoc.GetDepartmentById(id));
        }

        [HttpPost]
        public IActionResult Edit(Department? newDept) 
        {
            if(newDept is null)
                return BadRequest();
            DeptMoc.UpdateDepartment(newDept);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            DeptMoc.DeleteDepartment(id);
            return RedirectToAction("Index");
        }

    }
}
