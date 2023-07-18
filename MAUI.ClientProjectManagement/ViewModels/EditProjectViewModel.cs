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
    public class EditProjectViewModel : INotifyPropertyChanged
    {
        public EditProjectViewModel(int projectId) 
        {
            SelectedProject = ProjectService.Current.GetProject(projectId);
            OpenMonth = SelectedProject.OpenDate.Month;
            OpenDay = SelectedProject.OpenDate.Day;
            OpenYear = SelectedProject.OpenDate.Year;
            ClosedMonth = SelectedProject.ClosedDate.Month;
            ClosedDay = SelectedProject.ClosedDate.Day;
            ClosedYear = SelectedProject.ClosedDate.Year;
        }

        /*
        public ObservableCollection<Project> Projects
        {
            get
            {
                return new ObservableCollection<Project>(ProjectService.Current.Projects);
            }
        }
        */

        private Project selectedProject;
        public Project SelectedProject
        {
            get
            {
                return selectedProject;
            }
            set { selectedProject = value; }
        }

        private int openMonth;
        public int OpenMonth
        {
            get { return openMonth; }
            set { openMonth = value; }
        }

        private int openDay;
        public int OpenDay
        {
            get { return openDay; }
            set { openDay = value; }
        }

        private int openYear;
        public int OpenYear
        {
            get { return openYear; }
            set { openYear = value; }
        }

        private int closedDay;
        public int ClosedDay
        {
            get { return closedDay; }
            set { closedDay = value; }
        }

        private int closedMonth;
        public int ClosedMonth
        {
            get { return closedMonth; }
            set { closedMonth = value; }
        }

        private int closedYear;
        public int ClosedYear
        {
            get { return closedYear; }
            set { closedYear = value; }
        }

        public void EditProject()
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

            ProjectService.Current.EditProject(
                SelectedProject.Id,
                new DateTime(OpenYear, OpenMonth, OpenDay),
                new DateTime(ClosedYear, ClosedMonth, ClosedDay),
                SelectedProject.IsActive,
                SelectedProject.ShortName,
                SelectedProject.LongName,
                SelectedProject.ClientId
                );
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
