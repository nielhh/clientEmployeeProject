using Microsoft.EntityFrameworkCore;
using skeleton.Data;
using skeleton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace skeleton.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        public EmployeeRepository()
        {
            using var context = new APIDbContext();
          if(  context == null)  throw new ArgumentNullException(nameof(context));
      
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            using (var context = new APIDbContext())
            {
                return await context.Employees.ToListAsync();
            }
        }
        public async Task<Employee> GetEmployeeByID(int ID)
        {
            using (var context = new APIDbContext())
            {
                return await context.Employees.FindAsync(ID);
            }
        }
        public async Task<Employee> InsertEmployee(Employee objEmployee)
        {
            using (var context = new APIDbContext())
            {
                context.Employees.Add(objEmployee);
                await context.SaveChangesAsync();
                return objEmployee;
            }
        }
        public async Task<Employee> UpdateEmployee(Employee objEmployee)
        {
            using (var context = new APIDbContext())
            {
                context.Entry(objEmployee).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return objEmployee;
            }
        }
        public bool DeleteEmployee(int ID)
        {
                using (var context = new APIDbContext())
                {
                    bool result = false;
            var department = context.Clients.Find(ID);
            if (department != null)
            {
                    context.Entry(department).State = EntityState.Deleted;
                    context.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
                }
    }
}
