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
    public class EditTimeEntryViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Time> TimeEntries
        {
            get
            {
                return new ObservableCollection<Time>(TimeService.Current.TimeEntries);
            }
        }

        public Time SelectedTimeEntry
        {
            get
            {
                return TimeService.Current.SelectedTimeEntry;
            }
        }

        private decimal hours = TimeService.Current.SelectedTimeEntry.Hours;
        public decimal Hours
        {
            get { return hours; }
            set { hours = value; }
        }

        public void EditTimeEntry()
        {
            if (Hours < 0)
                Hours = 0;

            TimeService.Current.EditTimeEntry(SelectedTimeEntry.Date,
                SelectedTimeEntry.Narrative,
                Hours,
                SelectedTimeEntry.ProjectId,
                SelectedTimeEntry.EmployeeId);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
