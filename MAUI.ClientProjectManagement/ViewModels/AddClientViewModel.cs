using Library.ClientProjectManagement.Models;
using Library.ClientProjectManagement.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.ClientProjectManagement.ViewModels
{
    public class AddClientViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Client> Clients
        {
            get
            {
                return new ObservableCollection<Client>(ClientService.Current.Clients);
            }
        }

        public int NewClientId
        {
            get
            {
                if (ClientService.Current.Clients.Count == 0)
                    return 1;

                int index = ClientService.Current.Clients.Count - 1;
                return (ClientService.Current.Clients[index].Id+1);
            }
        }

        public int OpenMonth { get; set; }
        public int OpenDay { get; set; }
        public int OpenYear { get; set; }
        public int ClosedMonth { get; set; }
        public int ClosedDay { get; set; }
        public int ClosedYear { get; set; }
        public bool IsActive { get; set; }
        public String Name { get; set; }
        public String Notes { get; set; }


        public void AddClient()
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
            else if(OpenDay > DateTime.DaysInMonth(OpenYear,OpenMonth) )
                OpenDay = DateTime.DaysInMonth(OpenYear,OpenMonth);

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

            ClientService.Current.AddClient(new Client
            {
                Id = NewClientId,
                OpenDate= new DateTime(OpenYear,OpenMonth,OpenDay),
                ClosedDate= new DateTime(ClosedYear,ClosedMonth,ClosedDay),
                IsActive = IsActive,
                Name = Name,
                Notes = Notes
            });
            Reset();
        }

        public void Reset()
        {
            NotifyPropertyChanged("NewClientId");
            OpenMonth = 1; OpenDay = 1 ; OpenYear = 1 ;
            NotifyPropertyChanged("OpenMonth");
            NotifyPropertyChanged("OpenDay");
            NotifyPropertyChanged("OpenYear");
            ClosedMonth = 1; ClosedDay = 1; ClosedYear = 1;
            NotifyPropertyChanged("ClosedMonth");
            NotifyPropertyChanged("ClosedDay");
            NotifyPropertyChanged("ClosedYear");
            Name = string.Empty;
            Notes = string.Empty;
            NotifyPropertyChanged("Name");
            NotifyPropertyChanged("Notes");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
