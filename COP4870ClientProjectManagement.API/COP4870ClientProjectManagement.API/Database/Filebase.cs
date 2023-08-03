using COP4870ClientProjectManagement.API.EC;
using Library.ClientProjectManagement.Models;
using Newtonsoft.Json;

namespace COP4870ClientProjectManagement.API.Database
{
    public class Filebase
    {
        private string _root;
        private string _clientRoot;
        private string _projectRoot;
        private static Filebase? _instance;


        public static Filebase Current
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Filebase();
                }

                return _instance;
            }
        }

        private Filebase()
        {
            _root = @"C:\Users\phdra\Desktop\COP4870";
            _clientRoot = $"{_root}\\Clients";
            _projectRoot = $"{_root}\\Projects";
            //TODO: Add support for employees, times, bills
        }

        private int LastClientId => Clients.Any() ? Clients.Select(c => c.Id).Max() : 0;

        public Client AddOrUpdate(Client c)
        {
            //set up a new Id if one doesn't already exist
            //Add
            if(c.Id <= 0)
            {
                c.Id = LastClientId + 1;
            }

            var path = $"{_clientRoot}\\{c.Id}.json";

            //if the item has been previously persisted
            if(File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }

            //write the file
            File.WriteAllText(path, JsonConvert.SerializeObject(c));

            //return the item, which now has an id
            return c;
        }

        public List<Client> Clients
        {
            get
            {
                var root = new DirectoryInfo(_clientRoot);
                var _clients = new List<Client>();
                foreach (var clientFile in root.GetFiles())
                {
                    var client = JsonConvert.
                        DeserializeObject<Client>
                        (File.ReadAllText(clientFile.FullName));
                    if(client != null)
                    {
                        _clients.Add(client);
                    }
                }
                return _clients;
            }
        }

        public bool Delete(string id)
        {
            var path = $"{_clientRoot}\\{id}.json";

            //if the item has been previously persisted
            if (File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }

            return true;
        }
    }


}
