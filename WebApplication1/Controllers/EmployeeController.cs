using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDBContext _db;
        public EmployeeController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Employee> employees=_db.Employees.ToList();
            return View(employees);
        }

        public IActionResult AddEmployee() { 
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee obj)
        {
            if (obj.DepartmentID > 5)
            {
                ModelState.AddModelError("DepartmentID", "DepartmentID should not exceed 5");
            }
            if (ModelState.IsValid)
            {
                _db.Employees.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Employee added Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }
        public IActionResult EditEmployee(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            Employee? Employee1=_db.Employees.FirstOrDefault(x => x.ID == id);
            if (Employee1 == null)
            {
                return NotFound();
            }

            return View(Employee1);

        }
        [HttpPost]
        public IActionResult EditEmployee(Employee obj)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Employee edited Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }

        public IActionResult DeleteEmployee(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Employee? Employee1 = _db.Employees.FirstOrDefault(x => x.ID == id);
            if (Employee1 == null)
            {
                return NotFound();
            }

            return View(Employee1);

        }
        [HttpPost]
        public IActionResult DeleteEmployee(Employee obj)
        {
            
            
                _db.Employees.Remove(obj);
                _db.SaveChanges();
            TempData["Success"] = "Employee deleted Successfully";
            return RedirectToAction("Index");
            
        }

    }
}
