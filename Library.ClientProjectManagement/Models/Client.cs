using System;

namespace Library.ClientProjectManagement.Models
{

	public class Client
	{
		public int Id { get; set; }
		public DateTime OpenDate { get; set; }
		public DateTime ClosedDate { get; set; }
		public Boolean IsActive { get; set; }
		public String Name { get; set; }
		public String Notes { get; set; }

		public Client()
		{
			Id = 0;
			OpenDate = DateTime.Now;
			ClosedDate = DateTime.Now;
			IsActive = false;
			Name = string.Empty;
			Notes = string.Empty;
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
				
				"Id: " + Id
				+ "\nOpenDate: " + OpenDate
				+ "\nClosedDate: " + ClosedDate
				+ "\nIsActive: " + IsActive
				+ "\nName: " + Name
				+ "\nNotes: " + Notes + "\n";
				
		}
		
	}

}
