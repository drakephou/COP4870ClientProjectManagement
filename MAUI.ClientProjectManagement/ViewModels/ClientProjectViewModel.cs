
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
    public class ClientProjectViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Client> Clients 
        {
            get
            {
                return new ObservableCollection<Client>(ClientService.Current.Clients);
            }
        }

        public ObservableCollection<Project> Projects
        {
            get 
            {
                if(SelectedClient != null)
                {
                    return new ObservableCollection<Project>(ProjectService.Current.Filter(SelectedClient.Id));
                }
                return new ObservableCollection<Project>(ProjectService.Current.Projects);
            }
        }



        public Client SelectedClient { get; set; }
        public Project SelectedProject { get; set; }

        public void PassSelectedClient()
        {
            ClientService.Current.SelectedClient = SelectedClient;
        }

        public void PassSelectedProject()
        {
            ProjectService.Current.SelectedProject = SelectedProject;
        }

        public void DeleteClient()
        {
            if ( SelectedClient != null && !ProjectService.Current.clientIdExists(SelectedClient.Id) )
            {
                ClientService.Current.Delete(SelectedClient);
                SelectedClient = null;
            }
                
            NotifyPropertyChanged("Clients");
        }

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
            NotifyPropertyChanged("Clients");
            NotifyPropertyChanged("Projects");
        }

        public void Filter()
        {
            NotifyPropertyChanged("Projects");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
