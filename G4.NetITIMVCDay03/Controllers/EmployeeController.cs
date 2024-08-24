using G4.NetITIMVCDay03.Context;
using G4.NetITIMVCDay03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace G4.NetITIMVCDay03.Controllers
{
    public class EmployeeController : Controller
    {
        /*---------------------------------------------------------*/
        // Context
        ComapnyContext comapnyContext = new ComapnyContext();
        /*---------------------------------------------------------*/
        [HttpGet]
        public IActionResult Index()
        {
            var Employees = comapnyContext.Employees.Include(e => e.Department);
            return View(Employees);
        }
        /*---------------------------------------------------------*/
        [HttpGet]
        public IActionResult ViewDetails(int id)
        {
            var Employee = comapnyContext.Employees.Include(e => e.Department).FirstOrDefault(e => e.Id == id);
            return View(Employee);
        }
        /*---------------------------------------------------------*/
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(comapnyContext.Departments, "Id", "DeptName");
            return View();
        }
        /*---------------------------------------------------------*/
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            comapnyContext.Employees.Add(employee);
            comapnyContext.SaveChanges();
            return RedirectToAction("Index");
        }
        /*---------------------------------------------------------*/
    }
}
