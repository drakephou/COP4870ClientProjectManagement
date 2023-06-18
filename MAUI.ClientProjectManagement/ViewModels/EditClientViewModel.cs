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
    public class EditClientViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Client> Clients
        {
            get
            {
                return new ObservableCollection<Client>(ClientService.Current.Clients);
            }
        }

        public Client SelectedClient 
        {
            get
            {
                return ClientService.Current.SelectedClient; 
            }
        }

        private int openMonth = ClientService.Current.SelectedClient.OpenDate.Month;
        public int OpenMonth{ get { return openMonth; }
                              set { openMonth = value; } }

        private int openDay = ClientService.Current.SelectedClient.OpenDate.Day;
        public int OpenDay { get { return openDay; }
                             set { openDay = value; } }

        private int openYear = ClientService.Current.SelectedClient.OpenDate.Year;
        public int OpenYear
        {
            get { return openYear; }
            set { openYear = value; }
        }

        private int closedDay = ClientService.Current.SelectedClient.ClosedDate.Day;
        public int ClosedDay
        {
            get { return closedDay; }
            set { closedDay = value; }
        }

        private int closedMonth = ClientService.Current.SelectedClient.ClosedDate.Month;
        public int ClosedMonth
        {
            get { return closedMonth; }
            set { closedMonth = value; }
        }

        private int closedYear = ClientService.Current.SelectedClient.ClosedDate.Year;
        public int ClosedYear
        {
            get { return closedYear; }
            set { closedYear = value; }
        }




        public void EditClient()
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

            ClientService.Current.EditClient(SelectedClient.Id,
                new DateTime(OpenYear,OpenMonth,OpenDay),
                new DateTime(ClosedYear,ClosedMonth,ClosedDay),
                SelectedClient.IsActive, SelectedClient.Name,SelectedClient.Notes);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
