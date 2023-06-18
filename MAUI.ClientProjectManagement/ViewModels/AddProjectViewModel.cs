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
    public class AddProjectViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Project> Projects
        {
            get
            {
                return new ObservableCollection<Project>(ProjectService.Current.Projects);
            }
        }

        public int SelectedClientId
        {
            get
            {
                return ClientService.Current.SelectedClient.Id;
            }
        }

        public int NewProjectId
        {
            get
            {
                if (ProjectService.Current.Projects.Count == 0)
                    return 1;

                int index = ProjectService.Current.Projects.Count - 1;
                return (ProjectService.Current.Projects[index].Id + 1);
            }
        }

        public int OpenMonth { get; set; }
        public int OpenDay { get; set; }
        public int OpenYear { get; set; }
        public int ClosedMonth { get; set; }
        public int ClosedDay { get; set; }
        public int ClosedYear { get; set; }
        public bool IsActive { get; set; }
        public String ShortName { get; set; }
        public String LongName { get; set; }

        public void AddProject()
        {
            if (OpenYear > 9999)
                OpenYear = 9999;
            else if (OpenYear < 1)
                OpenYear = 1;
            if (OpenMonth < 1)
                OpenMonth = 1;
            else if (OpenMonth > 12)
                OpenMonth = 12;
            if (OpenDay < 1)
                OpenDay = 1;
            else if (OpenDay > DateTime.DaysInMonth(OpenYear, OpenMonth))
                OpenDay = DateTime.DaysInMonth(OpenYear, OpenMonth);

            if (ClosedYear > 9999)
                ClosedYear = 9999;
            else if (ClosedYear < 1)
                ClosedYear = 1;
            if (ClosedMonth < 1)
                ClosedMonth = 1;
            else if (ClosedMonth > 12)
                ClosedMonth = 12;
            if (ClosedDay < 1)
                ClosedDay = 1;
            else if (OpenDay > DateTime.DaysInMonth(ClosedYear, OpenMonth))
                ClosedDay = DateTime.DaysInMonth(ClosedYear, OpenMonth);

            ProjectService.Current.AddProject(new Project
            {
                Id = NewProjectId,
                OpenDate = new DateTime(OpenYear, OpenMonth, OpenDay),
                ClosedDate = new DateTime(ClosedYear, ClosedMonth, ClosedDay),
                IsActive = IsActive,
                ShortName = ShortName,
                LongName = LongName,
                ClientId = SelectedClientId
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }



}
