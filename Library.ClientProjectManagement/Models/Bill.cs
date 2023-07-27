using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ClientProjectManagement.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ProjectId { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime DueDate { get; set; }

        public Bill()
        {
            Id = 0;
            ClientId = 0;
            ProjectId = 0;
            TotalAmount = 0;
            DueDate = DateTime.Now;
        }

        public override string ToString()
        {
            return
                "BillId: " + Id
                + "\nClientId: " + ClientId
                + "\nProjectId: " + ProjectId
                + "\nTotalAmount: " + TotalAmount
                + "\nDueDate: " + DueDate.Date;
        }
    }
}
