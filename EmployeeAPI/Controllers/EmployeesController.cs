using EmployeeAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Ravi", Email = "ravi@gmail.com", Department = "IT", Salary = 50000 },
            new Employee { Id = 2, Name = "Priya", Email = "priya@gmail.com", Department = "HR", Salary = 45000 }
        };

        [HttpGet]
        public ActionResult<List<Employee>> GetAll()
        {
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetById(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();
            return Ok(emp);
        }

        [HttpPost]
        public ActionResult<Employee> Create(Employee emp)
        {
            emp.Id = employees.Max(e => e.Id) + 1;
            employees.Add(emp);
            return CreatedAtAction(nameof(GetById), new { id = emp.Id }, emp);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Employee updated)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();
            emp.Name = updated.Name;
            emp.Email = updated.Email;
            emp.Department = updated.Department;
            emp.Salary = updated.Salary;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null) return NotFound();
            employees.Remove(emp);
            return NoContent();
        }
    }
}