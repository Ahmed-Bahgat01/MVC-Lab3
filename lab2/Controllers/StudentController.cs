using lab2.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab2.Controllers
{
    public class StudentController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public ViewResult Index()
        {
            List<Student> stdList = new List<Student>()
            {
                new Student(10, "Ahmed"),
                new Student(20, "Bahgat")
            };
            return View(stdList);
        }
    }
}
