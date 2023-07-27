using Library.ClientProjectManagement.DTO;
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

		public Client(ClientDTO dto)
		{
			this.Id = dto.Id;
			this.OpenDate = dto.OpenDate;
			this.ClosedDate = dto.ClosedDate;
			this.IsActive = dto.IsActive;
			this.Name = dto.Name;
			this.Notes = dto.Notes;
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
