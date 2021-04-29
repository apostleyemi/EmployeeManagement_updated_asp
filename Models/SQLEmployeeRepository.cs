using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }
        public Employee Add(Employee employee)
        {
            // throw new NotImplementedException();
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public Employee Delete(int id)
        {
            // throw new NotImplementedException();

            Employee employee = context.Employees.Find(id);


            if(employee !=null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;

        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            // throw new NotImplementedException();

            return context.Employees;
        }

        public Employee GetEmployee(int Id)
        {
            // throw new NotImplementedException();

            return context.Employees.Find(Id);
        }

        public Employee Update(Employee employeeChanges)
        {
            //throw new NotImplementedException();

            var employee = context.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employeeChanges;


        }
    }
}
