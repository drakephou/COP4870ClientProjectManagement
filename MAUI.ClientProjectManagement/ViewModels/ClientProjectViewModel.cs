
using Library.ClientProjectManagement.Models;
using Library.ClientProjectManagement.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.ClientProjectManagement.ViewModels
{
    public class ClientProjectViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ClientViewModel> Clients 
        {
            get
            {
                if (SearchName != null)
                    return new ObservableCollection<ClientViewModel>
                        (ClientService
                        .Current.Search(SearchName)
                        .Select(c => new ClientViewModel(c)).ToList() );
                
                return new ObservableCollection<ClientViewModel>
                   (ClientService
                   .Current.Clients
                   .Select(c => new ClientViewModel(c)).ToList() );
            }
        }

        private ObservableCollection<ProjectViewModel> projects = new ObservableCollection<ProjectViewModel>
            (ProjectService
            .Current.Projects
            .Select(p => new ProjectViewModel(p)).ToList() );
        public ObservableCollection<ProjectViewModel> Projects
        {
            get 
            {
                /*
                if(SelectedClient != null)
                {
                    return new ObservableCollection<Project>(ProjectService.Current.Filter(SelectedClient.Model.Id));
                }
                */
                return projects;
            }
            private set { projects = value; }
        }



        public ClientViewModel SelectedClient { get; set; }
        public Project SelectedProject { get; set; }

        //To be removed after implementing ways to pass data
        public void PassSelectedClient()
        {
            ClientService.Current.SelectedClient = SelectedClient.Model;
        }
        

        public void PassSelectedProject()
        {
            ProjectService.Current.SelectedProject = SelectedProject;
        }

        /*
        public void DeleteClient()
        {
            if ( SelectedClient != null && !ProjectService.Current.clientIdExists(SelectedClient.Id) )
            {
                ClientService.Current.Delete(SelectedClient);
                SelectedClient = null;
            }
                
            NotifyPropertyChanged("Clients");
        }
        */

        public void DeleteProject()
        {
            if( SelectedProject != null )
            {
                ProjectService.Current.Delete(SelectedProject );
                SelectedProject = null;
            }

            NotifyPropertyChanged("Projects");
        }

        public void Refresh()
        {
            SelectedClient = null;
            SelectedProject = null;
            Unfilter();
            RefreshClients();
            RefreshProjects();
        }

        public void RefreshClients()
        {
            NotifyPropertyChanged("Clients");
        }

        public void RefreshProjects()
        {
            NotifyPropertyChanged("Projects");
        }

        public void Filter()
        {
            Projects = new ObservableCollection<ProjectViewModel>
                (ProjectService
                .Current.Filter()
                .Select(p => new ProjectViewModel(p)).ToList() );
            NotifyPropertyChanged("Projects");
        }

        public void Unfilter()
        {
            ProjectService.Current.FilterId = -1;
            Filter();
        }

        public String SearchName { get; set; }
        public void Search()
        {
            NotifyPropertyChanged("Clients");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
