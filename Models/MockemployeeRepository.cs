using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockemployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockemployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() {Id = 1, Name = "Mary", Department = "HR", Email = "mary@gmail.com"},
                new Employee() {Id = 2, Name = "Jane", Department = "HR", Email = "jane@gmail.com"},
                new Employee() {Id = 3, Name = "Watson", Department = "HR", Email = "watson@gmail.com"}
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
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
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }

        public Employee Update(Employee employeeChange)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChange.Id);
            if (employee != null)
            {
                employee.Name = employeeChange.Name;
                employee.Email = employeeChange.Email;
                employee.Department = employeeChange.Department;
            }
            return employee;
        }
    }
}
