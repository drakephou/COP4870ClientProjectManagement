using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library.ClientProjectManagement.Models
{
    public class Project
    {
        public int Id { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public Boolean IsActive { get; set; }
        public String ShortName { get; set; }
        public String LongName { get; set; }
        public int ClientId { get; set; }

        public Project()
        {
            Id = 0;
            OpenDate = DateTime.MinValue;
            ClosedDate = DateTime.MinValue;
            IsActive = false;
            ShortName = string.Empty;
            LongName = string.Empty;
            ClientId = 0;
        }

        public Project(int id, DateTime openDate, DateTime closedDate, Boolean isActive, String shortName, String longName, int clientId)
        {
            Id = id;
            OpenDate = openDate;
            ClosedDate = closedDate;
            IsActive = isActive;
            ShortName = shortName;
            LongName = longName;
            ClientId = clientId;
        }

        public override string ToString()
        {
            return "ClientId: " + ClientId
            + "\nId: " + Id
            + "\nOpenDate: " + OpenDate
            + "\nClosedDate: " + ClosedDate
            + "\nIsActive: " + IsActive
            + "\nShortName: " + ShortName
            + "\nLongName: " + LongName + "\n";
        }
    }
}
