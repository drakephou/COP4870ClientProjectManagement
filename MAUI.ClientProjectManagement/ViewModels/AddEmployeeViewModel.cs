using Library.ClientProjectManagement.Models;
using Library.ClientProjectManagement.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.ClientProjectManagement.ViewModels
{
    public class AddEmployeeViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Employee> Employees
        {
            get { return new ObservableCollection<Employee>(EmployeeService.Current.Employees); }
        }
        public int NewEmployeeId
        {
            get
            {
                if (EmployeeService.Current.Employees.Count == 0)
                    return 1;
                int index = EmployeeService.Current.Employees.Count - 1;
                return EmployeeService.Current.Employees[index].Id+1;
            }
        }
        public String Name { get; set; }
        public decimal Rate { get; set; }

        public void AddEmployee()
        {
            if(Rate < 0)
                Rate = 0;
            EmployeeService.Current.AddEmployee(new Employee 
            { 
                Id = NewEmployeeId,
                Name = Name,
                Rate = Rate
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
