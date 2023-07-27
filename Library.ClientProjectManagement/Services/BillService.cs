using Library.ClientProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ClientProjectManagement.Services
{
    public class BillService
    {
        private static BillService? instance;

        public static BillService Current
        {
            get
            {
                if(instance == null)
                {
                    instance = new BillService();
                }
                return instance;
            }
        }

        private BillService()
        {
            bills = new List<Bill>();
        }

        private List<Bill> bills;
        public List<Bill> Bills
        {
            get { return bills; }
        }

        public void GenerateBill(int projectId, int month, int day, int year)
        {
            if (year > 9999)
                year = 9999;
            else if (year < 1)
                year = 1;
            if (month < 1)
                month = 1;
            else if (month > 12)
                month = 12;
            if (day < 1)
                day = 1;
            else if (day > DateTime.DaysInMonth(year, month))
                day = DateTime.DaysInMonth(year, month);

            DateTime dueDate = new DateTime(year, month, day);
            bills.Add(new Bill
            {
                Id = bills.Count + 1,
                ClientId = ProjectService.Current.GetProject(projectId).ClientId,
                ProjectId = projectId,
                TotalAmount = TimeService.Current.CalculateTotalAmount(projectId),
                DueDate = dueDate
            });
        }
    }
}
