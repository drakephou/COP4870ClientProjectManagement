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
    public class ProjectBillViewModel : INotifyPropertyChanged
    {
        public ProjectBillViewModel(int projectId)
        {
            ProjectId = projectId;
        }
        public int ProjectId { get; set; }
        public ObservableCollection<Bill> ProjectBills
        {
            get
            {
                return new ObservableCollection<Bill>(
                    BillService.Current.Bills.
                    Where(b => b.ProjectId == ProjectId).ToList());
            }
        }

        public string Display
        {
            get
            {
                return "Viewing Bills for Project "+ ProjectId;
            }
        }

        public int MonthDue { get; set; }
        public int YearDue { get; set; }
        public int DayDue { get; set; }

        public void GenerateBill()
        {
            BillService.Current.GenerateBill(ProjectId, MonthDue, DayDue, YearDue);
            NotifyPropertyChanged(nameof(ProjectBills));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
