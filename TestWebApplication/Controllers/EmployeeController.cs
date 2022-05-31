using Microsoft.AspNetCore.Mvc;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System;

namespace TestWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly TestDBEntities _dbContext;

        public EmployeeController(TestDBEntities dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchString">Search's of FN, LN Or Desgnation</param>
        /// <returns></returns>
        [HttpGet]
        public List<Employee> GetEmployee(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                var employees = _dbContext.Employees;
                return employees.ToList();
            }
            else
            {
                var employees = _dbContext.Employees.Where(e => e.FirstName.Contains(searchString) || e.LastName.Contains(searchString) || e.Designation.Contains(searchString));
                return employees.ToList();
            }
        }

        [HttpPost]
        public string SaveEmployee([FromBody] Employee employee)
        {
            try
            {
                var entity = _dbContext.Employees.FirstOrDefault(e=>e.EmployeeId == employee.EmployeeId);
                if (entity != null)
                {
                    entity = employee;
                    _dbContext.SaveChangesAsync();
                    return "Employee with Emp ID:'" + employee.EmployeeId + "' is updated successfully!";
                }
                else
                {
                    _dbContext.Employees.Add(employee);
                    _dbContext.SaveChanges();
                    return "Employee with Emp ID:'" + employee.EmployeeId + "' is created successfully!";
                }
            }
            catch (Exception ex)
            {
                return "Error occurred saving '" + employee.EmployeeId + "'";
            }

        }

        [HttpDelete]
        public string DeleteEmployee(int empIdToDelete)
        {
            try
            {
                var entityToDelete = _dbContext.Employees.FirstOrDefault(e=>e.EmployeeId==empIdToDelete);
                if (entityToDelete != null)
                {

                    _dbContext.Employees.Remove(entityToDelete);
                    _dbContext.SaveChanges();
                }
                return "'" + empIdToDelete + "' is deleted successfully!";
            }
            catch (Exception ex)
            {
                return "Error occurred while deleting '" + empIdToDelete + "'";
            }
        }
        
    }
}
