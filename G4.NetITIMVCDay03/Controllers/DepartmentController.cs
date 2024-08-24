using G4.NetITIMVCDay03.Context;
using G4.NetITIMVCDay03.Models;
using Microsoft.AspNetCore.Mvc;

namespace G4.NetITIMVCDay03.Controllers
{
    public class DepartmentController : Controller
    {
        /*---------------------------------------------------------*/
        // Context
        ComapnyContext comapnyContext = new ComapnyContext();
        /*---------------------------------------------------------*/
        // Get All => Index
        [HttpGet]
        public IActionResult Index()
        {
            //var departments = comapnyContext.Departments.ToList(); // Cast To List
            var departments = comapnyContext.Departments;
            ViewBag.Departments = departments;
            return View();
        }
        /*---------------------------------------------------------*/
        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var department = comapnyContext.Departments.Find(id);
            ViewBag.Department = department;
            return View();
        }
        /*---------------------------------------------------------*/
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        /*---------------------------------------------------------*/
        [HttpPost]
        public IActionResult Create(Department department)
        {
            comapnyContext.Departments.Add(department);
            comapnyContext.SaveChanges();
            return RedirectToAction("Index");
        }
        /*---------------------------------------------------------*/
    }
}
