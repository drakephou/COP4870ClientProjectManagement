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
    public class AddTimeEntryViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Time> TimeEntries
        {
            get { return new ObservableCollection<Time>(TimeService.Current.TimeEntries);}
        }

        public DateTime NewDateTime
        {
            get { return DateTime.Now; }
        }

        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public decimal Hours { get; set; }
        public string Narrative { get; set; }

        public void AddTimeEntry()
        {
            if(Hours < 0)
                Hours = 0;

            TimeService.Current.AddTimeEntry(new Time
            {
                Date = NewDateTime,
                Narrative = Narrative,
                Hours = Hours,
                ProjectId = ProjectId,
                EmployeeId = EmployeeId,
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
