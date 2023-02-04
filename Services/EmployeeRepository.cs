using Day8.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
namespace Day8.Services
{
    public class EmployeeRepository
    {
        CompanyDBContext DB = new CompanyDBContext();
        public List<Employee> GetAll()
        {
            List<Employee> empList = DB.Employees.ToList();
            return empList;
        }

        public Employee GetById(int id)
        {
            Employee emp = DB.Employees.Where(E => E.SSN == id).SingleOrDefault();
            return emp;
        }

        public int Update(int id, Employee emp)
        {
            Employee oldEmp = DB.Employees.Where(E => E.SSN == id).SingleOrDefault();
            oldEmp.Fname = emp.Fname;
            oldEmp.Lname = emp.Lname;
            oldEmp.Salary = emp.Salary;
            oldEmp.Sex = emp.Sex;
            oldEmp.BirthDate = emp.BirthDate;
            oldEmp.Address = emp.Address;
            oldEmp.DeptId = emp.DeptId;
            int rowsAffected = DB.SaveChanges();
            return rowsAffected;
        }

        public int Create(Employee emp)
        {
            DB.Employees.Add(emp);
            int rowsAffected = DB.SaveChanges();
            return rowsAffected;
        }

        public int Delete(int id)
        {
            Employee empToDelete = DB.Employees.Where(D => D.SSN == id).SingleOrDefault();
            DB.Employees.Remove(empToDelete);
            int rowsAffected = DB.SaveChanges();
            return rowsAffected;
        }
    }
}
