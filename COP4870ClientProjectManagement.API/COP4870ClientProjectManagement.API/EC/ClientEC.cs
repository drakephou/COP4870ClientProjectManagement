using COP4870ClientProjectManagement.API.Database;
using Library.ClientProjectManagement.DTO;
using Library.ClientProjectManagement.Models;

namespace COP4870ClientProjectManagement.API.EC
{
    public class ClientEC
    {
        public ClientDTO Add(ClientDTO dto)
        {
            dto.Id = FakeDatabase.LastClientId + 1;
            FakeDatabase.Clients.Add(new Client(dto));

            return dto;
        }

        public ClientDTO? Get(int id)
        {
            var returnVal = FakeDatabase.Clients
                .FirstOrDefault(c => c.Id == id)
                ?? new Client();

            return new ClientDTO(returnVal);
        }

        public ClientDTO Update(ClientDTO dto)
        {
            var clientToUpdate
                = FakeDatabase.Clients
                .FirstOrDefault(c => c.Id == dto.Id);
            var index = FakeDatabase.Clients.IndexOf(clientToUpdate);
            if(clientToUpdate != null && index != null)
            {
                FakeDatabase.Clients.RemoveAt(index);
                FakeDatabase.Clients.Insert(index, new Client(dto));
            }
            

            return dto;
        }

        public ClientDTO? Delete(int id)
        {
            var clientToDelete = FakeDatabase.Clients.FirstOrDefault(c => c.Id == id);
            if (clientToDelete != null)
            {
                FakeDatabase.Clients.Remove(clientToDelete);
                return new ClientDTO(clientToDelete);
            }
            return clientToDelete!= null
                ? new ClientDTO(clientToDelete)
                : null;
        }

        public IEnumerable<ClientDTO> Search(string query = "") 
        {
            return FakeDatabase.Clients.
                Where(c => c.Name.ToUpper()
                .Contains(query.ToUpper()))
                .Take(1000)
                .Select(c => new ClientDTO(c));

        }
    }
}
