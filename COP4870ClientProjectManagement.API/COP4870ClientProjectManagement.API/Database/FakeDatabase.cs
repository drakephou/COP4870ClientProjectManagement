using Library.ClientProjectManagement.Models;
using Library.ClientProjectManagement.Services;

namespace COP4870ClientProjectManagement.API.Database
{
    public static class FakeDatabase
    {
        public static List<Client> Clients = new List<Client>
        {
            new Client
            {
                Id = 1,
                OpenDate = DateTime.Now,
                ClosedDate = DateTime.Now,
                IsActive = false,
                Name = "Test1",
                Notes = "Test1"
            },
            new Client
            {
                Id = 2,
                OpenDate = DateTime.Now,
                ClosedDate = DateTime.Now,
                IsActive = false,
                Name = "Test2",
                Notes = "Test2"
            }
        };

        public static int LastClientId
            => Clients.Any() ? Clients.Select(c => c.Id).Max() : 0;
        
    }
    
}
