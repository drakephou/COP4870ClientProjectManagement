using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ClientProjectManagement.Models
{
    public class Employee
    {
        public String Name { get; set; }
        public decimal Rate { get; set; }
        public int Id { get; set; }

        public Employee() 
        {
            Name = string.Empty;
            Rate = 0;
            Id = 0;
        }

        public override string ToString()
        {
            return "Id: " + Id + "\n" +
                "Name: " + Name + "\n" +
                "Rate: " + Rate; 
        }
    }
}
