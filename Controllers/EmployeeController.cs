using Day8.Models;
using Day8.Services;
using Microsoft.AspNetCore.Mvc;

namespace Day8.Controllers
{
    public class EmployeeController : Controller
    {

        EmployeeRepository empRepo;
        public EmployeeController()
        {
            empRepo = new EmployeeRepository();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetEmployees()
        {
            return View("ShowEmployees", empRepo.GetAll());
        }

        public IActionResult GetSingleEmployee(int id)
        {

            Employee employee = empRepo.GetById(id);
            if (employee == null)
                return View("Error");
            else
                return View(employee);
        }

        public IActionResult AddEmployee(Employee emp)
        {
            empRepo.Create(emp);
            return View("ShowEmployees");
        }

        public IActionResult UpdateEmployee(int id, Employee emp)
        {
            empRepo.Update(id, emp);
            return View("ShowEmployees");
        }

        public IActionResult DeleteEmployee(int id)
        {
            empRepo.Delete(id);
            return View("ShowEmployees");
        }


    }
}
