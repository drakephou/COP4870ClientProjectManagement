using Library.ClientProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Library.ClientProjectManagement.Services
{
    public class TimeService
    {
        private static TimeService? instance;

        public static TimeService Current
        {
            get
            {
                if (instance == null)
                    instance = new TimeService();
                return instance;
            }
        }

        private List<Time> timeEntries;
        private Time? selectedTimeEntry;
        private TimeService() 
        {
            timeEntries = new List<Time>();
            timeEntries.Add(new Time
            {
                Date = DateTime.Now,
                Narrative = "Test1",
                Hours = 1,
                ProjectId = 1,
                EmployeeId = 1,
            });
            timeEntries.Add(new Time
            {
                Date = DateTime.Now,
                Narrative = "Test2",
                Hours = 2,
                ProjectId = 2,
                EmployeeId = 2,
            });
        }

        public void Delete(DateTime deleteChoice)
        {
            var timeEntryToDelete = timeEntries.FirstOrDefault(s => s.Date == deleteChoice);
            if (timeEntryToDelete != null)
            {
                timeEntries.Remove(timeEntryToDelete);
            }
        }

        public List<Time> TimeEntries
        { 
            get { return timeEntries; }
            set { timeEntries = value; }
        }

        public Time? SelectedTimeEntry
        {
            get { return selectedTimeEntry; }
            set { selectedTimeEntry = value; }
        }

        public void AddTimeEntry(Time timeEntry)
        { 
            timeEntries.Add(timeEntry); 
        }

        public void EditTimeEntry(DateTime date, String narrative, decimal hours, int projectId, int employeeId)
        {
            var timeEntry = timeEntries.FirstOrDefault(t => t.Date == date);
            if (timeEntry != null)
            {
                timeEntry.Narrative = narrative;
                timeEntry.Hours = hours;
                timeEntry.ProjectId = projectId;
                timeEntry.EmployeeId = employeeId;
         
            
            }
        }

        public decimal CalculateTotalAmount(int projectId)
        {
            decimal totalAmount = 0;
            foreach (var timeEntry in timeEntries)
            {
                if(timeEntry.ProjectId == projectId)
                {
                    totalAmount += timeEntry.Hours * EmployeeService.Current.GetEmployee(timeEntry.EmployeeId).Rate;
                }
            }
            return totalAmount;
        }
    }
}
