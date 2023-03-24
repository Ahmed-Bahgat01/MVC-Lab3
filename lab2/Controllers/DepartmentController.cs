using lab2.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab2.Controllers
{
    public class DepartmentController : Controller
    {
        public ViewResult Index()
        {
            List<Department> deptList = new List<Department>()
            {
                new Department(1, "IT"),
                new Department(2, "Sales")
            };
            ViewBag.Departments = deptList;

            return View();
        }
    }
}
