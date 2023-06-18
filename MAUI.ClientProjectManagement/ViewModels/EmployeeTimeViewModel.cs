using Library.ClientProjectManagement.Models;
using Library.ClientProjectManagement.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.ClientProjectManagement.ViewModels
{
    public class EmployeeTimeViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Employee> Employees
        {
            get
            {
                return new ObservableCollection<Employee>(EmployeeService.Current.Employees);
            }
        }

        public ObservableCollection<Time> TimeEntries
        {
            get
            {
                return new ObservableCollection<Time>(TimeService.Current.TimeEntries);
            }
        }

        public Employee SelectedEmployee { get; set; }
        public Time SelectedTimeEntry { get; set; }

        public void PassSelectedEmployee()
        {
            if(SelectedEmployee != null)
            {
                EmployeeService.Current.SelectedEmployee = SelectedEmployee;
            }
        }

        public void PassSelectedTimeEntry()
        {
            if(SelectedTimeEntry != null)
            {
                TimeService.Current.SelectedTimeEntry = SelectedTimeEntry;
            }
        }

        public void DeleteEmployee()
        {
            if (SelectedEmployee != null)
            {
                EmployeeService.Current.Delete(SelectedEmployee.Id);
                NotifyPropertyChanged("Employees");
            }
        }

        public void DeleteTimeEntry()
        {
            if (SelectedTimeEntry != null)
            {
                TimeService.Current.Delete(SelectedTimeEntry.Date);
                NotifyPropertyChanged("TimeEntries");
            }
        }

        public void Refresh()
        {
            NotifyPropertyChanged("Employees");
            NotifyPropertyChanged("TimeEntries");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
