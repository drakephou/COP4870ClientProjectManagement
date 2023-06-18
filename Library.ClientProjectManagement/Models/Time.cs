using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ClientProjectManagement.Models
{
    public class Time
    {
        public DateTime Date { get; set; }
        public String Narrative { get; set; }
        public decimal Hours { get; set; }
        public int ProjectId { get; set; }
        public int EmployeeId { get; set; }

        public Time()
        {
            Date = DateTime.Now;
            Narrative = string.Empty;
            Hours = 0;
            ProjectId = 0;
            EmployeeId = 0;
        }

        public override string ToString()
        {
            return 
                "Date: " + Date + "\n" +
                "EmployeeId: " + EmployeeId + "\n" +
                "ProjectId: " + ProjectId + "\n" +
                "Hours: " + Hours + "\n" +
                "Narrative: " + Narrative;
        }
    }
}
