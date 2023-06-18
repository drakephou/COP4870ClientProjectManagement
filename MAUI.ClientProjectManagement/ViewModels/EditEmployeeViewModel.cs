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
    public class EditEmployeeViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Employee> Employees
        {
            get { return new ObservableCollection<Employee>(EmployeeService.Current.Employees); }
        }

        public Employee SelectedEmployee
        {
            get { return EmployeeService.Current.SelectedEmployee; }
        }

        private decimal rate = EmployeeService.Current.SelectedEmployee.Rate;
        public decimal Rate {
            get { return rate; }
            set { rate = value; }
        }

        public void EditEmployee()
        {
            if(Rate < 0)
                Rate = 0;

            EmployeeService.Current.EditEmployee(SelectedEmployee.Id, SelectedEmployee.Name, Rate);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
