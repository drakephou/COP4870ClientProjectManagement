using Library.ClientProjectManagement.Models;
using Library.ClientProjectManagement.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.ClientProjectManagement.ViewModels
{
    public class ClientBillViewModel
    {
        public ClientBillViewModel(int clientId) 
        {
            ClientId = clientId;
        }

        public int ClientId { get; set; }

        public string Display
        {
            get
            {
                return "Showing Bills for ClientId " + ClientId
                    + "\nName: " + ClientService.Current.GetClient(ClientId).Name;
            }
        }

        public ObservableCollection<Bill> ClientBills
        {
            get
            {
                return new ObservableCollection<Bill>(
                    BillService.Current.Bills.
                    Where(b => b.ClientId == ClientId).ToList());
            }
        }

    }
}
