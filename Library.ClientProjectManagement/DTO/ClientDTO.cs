using Library.ClientProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ClientProjectManagement.DTO
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public Boolean IsActive { get; set; }
        public String Name { get; set; }
        public String Notes { get; set; }

        public ClientDTO()
        {
            Id = 0;
            OpenDate = DateTime.Now;
            ClosedDate = DateTime.Now;
            IsActive = false;
            Name = string.Empty;
            Notes = string.Empty;
        }

        public ClientDTO(Client c)
        {
            this.Id = c.Id;
            this.OpenDate = c.OpenDate;
            this.ClosedDate = c.ClosedDate;
            this.IsActive = c.IsActive;
            this.Name = c.Name;
            this.Notes = c.Notes;
        }

        /*
		public Client(int Id, DateTime OpenDate, DateTime ClosedDate, Boolean IsActive, String Name, String Notes)
		{
			this.Id = Id;
			this.OpenDate = OpenDate;
			this.ClosedDate = ClosedDate;
			this.IsActive = IsActive;
			this.Name = Name;
			this.Notes = Notes;
		}
		*/


        public override string ToString()
        {
            return //$"{Id}. {Name}";

                "ClientId: " + Id
                + "\nName: " + Name
                + "\nNotes: " + Notes
                + "\nOpenDate: " + OpenDate.ToShortDateString()
                + "\nClosedDate: " + ClosedDate.ToShortDateString()
                + "\nIsActive: " + IsActive;

        }
    }
}
