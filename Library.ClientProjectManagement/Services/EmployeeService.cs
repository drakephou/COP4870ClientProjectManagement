using Library.ClientProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Library.ClientProjectManagement.Services
{
    public class EmployeeService
    {
        private static EmployeeService? instance;
        public static EmployeeService Current
        {
            get
            {
                if (instance == null)
                    instance = new EmployeeService();
                return instance;
            }
        }

        private List<Employee> employees;
        private Employee? selectedEmployee;
        public EmployeeService()
        {
            employees = new List<Employee>();
            employees.Add(new Employee
            {
                Name = "Test1",
                Rate = 100,
                Id = 1
            });
            employees.Add(new Employee
            {
                Name = "Test2",
                Rate = 200,
                Id = 2
            });
        }

        public List<Employee> Employees 
        {
            get { return employees; }
            set { employees = value; }
        }

        public Employee? SelectedEmployee
        {
            get { return selectedEmployee; }
            set { selectedEmployee = value; }
        }

        public void Delete(int deleteChoice)
        {
            var employeeToDelete = employees.FirstOrDefault(s => s.Id == deleteChoice);
            if (employeeToDelete != null)
            {
                employees.Remove(employeeToDelete);
            }
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void EditEmployee(int id, String name, decimal rate)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employee.Name = name;
                employee.Rate = rate;
            }
        }

        public Employee GetEmployee(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }
    }
}
