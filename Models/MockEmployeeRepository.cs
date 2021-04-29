using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {

        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() { Id=1, Name="Adedayo Peter", Gender=Gender.Male, statelist=Statelist.Abia, Department=Dept.ACCADEMIC, Email="dayo@techspace.com.ng", Phone="09083489232"},
                new Employee() { Id=2, Name="Oluyemi Grace", Gender=Gender.Female, statelist=Statelist.Adamawa, Department=Dept.HR, Email="Oluyemi@techspace.com.ng", Phone="08098728937"},
                new Employee() { Id=3, Name="John Kufor",Gender=Gender.Female, statelist=Statelist.Lagos, Department=Dept.IT, Email="kufor@techspace.com.ng",  Phone="070287823712"},
                new Employee() { Id=4, Name="Oluyemi Ayo", Gender=Gender.Male, statelist=Statelist.Osun, Department=Dept.PPW, Email="Oluyemi@techspace.com.ng", Phone="09083489232"},
                new Employee() { Id=5, Name="Ojo James", Gender=Gender.Female, statelist=Statelist.Oyo, Department=Dept.STUDENT, Email="opebijames@techspace.com.ng", Phone="080289123183"},

            };
        }

        public Employee Add(Employee employee)
        {
            //  throw new NotImplementedException();

               employee.Id = _employeeList.Max(e => e.Id) + 1;
              _employeeList.Add(employee);
               return employee;
        }

        public Employee Delete(int id)
        {
            // throw new NotImplementedException();
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == id);

            if(employee != null)
            {
                _employeeList.Remove(employee);
            }

            return employee; 

        }

        public IEnumerable<Employee> GetAllEmployee()
        {

            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            //throw new NotImplementedException();

            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }

        public Employee Update(Employee employeeChanges)
        {
            // throw new NotImplementedException();

            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if(employee != null)
            {
                employee.Name = employee.Name;
                employee.Email = employee.Email;
                employee.Department = employee.Department;
                employee.Phone = employee.Phone;
                employee.Gender = employee.Gender;
                employee.statelist = employee.statelist;
            }
            return employee;
        }
    }
}
