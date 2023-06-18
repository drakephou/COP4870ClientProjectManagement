using Library.ClientProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ClientProjectManagement.Services
{
    public class ClientService
    {
        private static ClientService? instance;

        public static ClientService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new ClientService();
                }
                return instance;
            }
        }

        private List<Client> clients;
        private Client? selectedClient;
        private ClientService()
        {
            clients = new List<Client>();
            clients.Add(new Client
            {
                Id = 1,
                OpenDate = DateTime.Now,
                ClosedDate = DateTime.Now,
                IsActive = false,
                Name = "Test1",
                Notes = "Test1"
            });
            clients.Add( new Client
            {
                Id = 2,
                OpenDate = DateTime.Now,
                ClosedDate = DateTime.Now,
                IsActive = false,
                Name = "Test2",
                Notes = "Test2"
            }
            );
        }

        public List<Client> Clients
        { 
            get 
            {
                return clients;
            }
            set { clients = value; }
        }

        public Client? SelectedClient
        {
            get
            {
                return selectedClient;
            }
            set { selectedClient = value; }
        }

        public Client? GetClient(int id)
        { 
            return clients.FirstOrDefault(e => e.Id == id);
        }

        public void Create()
        {
            bool formatCheck = true;

            int Id = -1;
            while (formatCheck)
            {
                Console.WriteLine("Id: ");
                try { Id = int.Parse(Console.ReadLine() ?? "0"); }
                catch (FormatException) { Console.WriteLine("Please enter an integer"); }
                finally
                {
                    if (Id >= 0)
                        formatCheck = false;
                    else
                        Console.WriteLine("Please enter a positive integer");
                }    
            }

            Console.WriteLine("OpenDate: ");
            DateTime OpenDate;
            int month = -1, day = -1, year = -1;
            formatCheck = true;
            while (formatCheck)
            {
                Console.WriteLine("Year: ");
                try { year = int.Parse(Console.ReadLine() ?? "1"); }
                catch (FormatException) { Console.WriteLine("Please enter an integer"); }
                finally
                {
                    if (year >= 1 && year <= 9999)
                        formatCheck = false;
                    else
                        Console.WriteLine("Please enter a valid year (1 to 9999)");
                }
            }
            formatCheck = true;
            while (formatCheck)
            {
                Console.WriteLine("Month: ");
                try { month = int.Parse(Console.ReadLine() ?? "1"); }
                catch (FormatException) { Console.WriteLine("Please enter an integer valid month (1 to 12)"); }
                finally
                {
                    if (month >= 1 && month <= 12)
                        formatCheck = false;
                    else
                        Console.WriteLine("Please enter a positive integer");
                }
            }
            formatCheck = true;
            while (formatCheck)
            {
                Console.WriteLine("Day: ");
                try { day = int.Parse(Console.ReadLine() ?? "1"); }
                catch (FormatException) { Console.WriteLine("Please enter an integer"); }
                finally
                {
                    if (day >= 1 && day <= DateTime.DaysInMonth(year, month))
                        formatCheck = false;
                    else
                        Console.WriteLine("Please enter a valid day (1 to " + DateTime.DaysInMonth(year, month) + ")");
                }
            }
            OpenDate = new DateTime(year, month, day);

            Console.WriteLine("ClosedDate: ");
            DateTime ClosedDate;
            month = -1; day = -1; year = -1;
            formatCheck = true;
            while (formatCheck)
            {
                Console.WriteLine("Year: ");
                try { year = int.Parse(Console.ReadLine() ?? "1"); }
                catch (FormatException) { Console.WriteLine("Please enter an integer"); }
                finally
                {
                    if (year >= 1 && year <= 9999)
                        formatCheck = false;
                    else
                        Console.WriteLine("Please enter a valid year (1 to 9999)");
                }
            }
            formatCheck = true;
            while (formatCheck)
            {
                Console.WriteLine("Month: ");
                try { month = int.Parse(Console.ReadLine() ?? "1"); }
                catch (FormatException) { Console.WriteLine("Please enter an integer valid month (1 to 12)"); }
                finally
                {
                    if (month >= 1 && month <= 12)
                        formatCheck = false;
                    else
                        Console.WriteLine("Please enter a positive integer");
                }
            }
            formatCheck = true;
            while (formatCheck)
            {
                Console.WriteLine("Day: ");
                try { day = int.Parse(Console.ReadLine() ?? "1"); }
                catch (FormatException) { Console.WriteLine("Please enter an integer"); }
                finally
                {
                    if (day >= 1 && day <= DateTime.DaysInMonth(year, month))
                        formatCheck = false;
                    else
                        Console.WriteLine("Please enter a valid day (1 to " + DateTime.DaysInMonth(year, month) + ")");
                }
            }
            ClosedDate = new DateTime(year, month, day);

            Boolean IsActive = false;
            while (true)
            {
                Console.WriteLine("IsActive: ");
                try { IsActive = bool.Parse(Console.ReadLine() ?? "false"); break; }
                catch (FormatException) { Console.WriteLine("Please enter \"true\" or \"false\""); }
            }
            
            Console.WriteLine("Name: ");
            String Name = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Notes: ");
            String Notes = Console.ReadLine() ?? string.Empty;

            clients.Add(new Client
            {
                Id = Id,
                OpenDate = OpenDate,
                ClosedDate = ClosedDate,
                IsActive = IsActive,
                Name = Name,
                Notes = Notes
            });

            Console.WriteLine("New Client added to List");
            Console.WriteLine();
        }
        public void Read()
        {
            Console.WriteLine("Listing all Clients");
            clients.ForEach(Console.WriteLine);
        }
        public void Update(int updateChoice) 
        {
            var clientToUpdate = clients.FirstOrDefault(s => s.Id == updateChoice);
            if (clientToUpdate != null)
            {
                bool formatCheck = true;
                Console.WriteLine("Updated OpenDate: ");
                int month = -1, day = -1, year = -1;
                formatCheck = true;
                while (formatCheck)
                {
                    Console.WriteLine("Year: ");
                    try { year = int.Parse(Console.ReadLine() ?? "1"); }
                    catch (FormatException) { Console.WriteLine("Please enter an integer"); }
                    finally
                    {
                        if (year >= 1 && year <= 9999)
                            formatCheck = false;
                        else
                            Console.WriteLine("Please enter a valid year (1 to 9999)");
                    }
                }
                formatCheck = true;
                while (formatCheck)
                {
                    Console.WriteLine("Month: ");
                    try { month = int.Parse(Console.ReadLine() ?? "1"); }
                    catch (FormatException) { Console.WriteLine("Please enter an integer valid month (1 to 12)"); }
                    finally
                    {
                        if (month >= 1 && month <= 12)
                            formatCheck = false;
                        else
                            Console.WriteLine("Please enter a positive integer");
                    }
                }
                formatCheck = true;
                while (formatCheck)
                {
                    Console.WriteLine("Day: ");
                    try { day = int.Parse(Console.ReadLine() ?? "1"); }
                    catch (FormatException) { Console.WriteLine("Please enter an integer"); }
                    finally
                    {
                        if (day >= 1 && day <= DateTime.DaysInMonth(year, month))
                            formatCheck = false;
                        else
                            Console.WriteLine("Please enter a valid day (1 to " + DateTime.DaysInMonth(year, month) + ")");
                    }
                }
                clientToUpdate.OpenDate = new DateTime(year, month, day);

                Console.WriteLine("Updated ClosedDate: ");
                month = -1; day = -1; year = -1;
                formatCheck = true;
                while (formatCheck)
                {
                    Console.WriteLine("Year: ");
                    try { year = int.Parse(Console.ReadLine() ?? "1"); }
                    catch (FormatException) { Console.WriteLine("Please enter an integer"); }
                    finally
                    {
                        if (year >= 1 && year <= 9999)
                            formatCheck = false;
                        else
                            Console.WriteLine("Please enter a valid year (1 to 9999)");
                    }
                }
                formatCheck = true;
                while (formatCheck)
                {
                    Console.WriteLine("Month: ");
                    try { month = int.Parse(Console.ReadLine() ?? "1"); }
                    catch (FormatException) { Console.WriteLine("Please enter an integer valid month (1 to 12)"); }
                    finally
                    {
                        if (month >= 1 && month <= 12)
                            formatCheck = false;
                        else
                            Console.WriteLine("Please enter a positive integer");
                    }
                }
                formatCheck = true;
                while (formatCheck)
                {
                    Console.WriteLine("Day: ");
                    try { day = int.Parse(Console.ReadLine() ?? "1"); }
                    catch (FormatException) { Console.WriteLine("Please enter an integer"); }
                    finally
                    {
                        if (day >= 1 && day <= DateTime.DaysInMonth(year, month))
                            formatCheck = false;
                        else
                            Console.WriteLine("Please enter a valid day (1 to " + DateTime.DaysInMonth(year, month) + ")");
                    }
                }
                clientToUpdate.ClosedDate = new DateTime(year, month, day);

                while (true)
                {
                    Console.WriteLine("Updated IsActive: ");
                    try { clientToUpdate.IsActive = bool.Parse(Console.ReadLine() ?? "false"); break; }
                    catch (FormatException) { Console.WriteLine("Please enter \"true\" or \"false\""); }
                }
                

                Console.WriteLine("Updated Name: ");
                clientToUpdate.Name = Console.ReadLine() ?? string.Empty;

                Console.WriteLine("Updated Notes: ");
                clientToUpdate.Notes = Console.ReadLine() ?? string.Empty;


            }
            else
            {
                Console.WriteLine("No Such Id in List of Clients; No Changes Made\n");
            }
        }
        public void Delete(int deleteChoice) 
        {
            var clientToDelete = clients.FirstOrDefault(s => s.Id == deleteChoice);
            if (clientToDelete != null)
            {
                clients.Remove(clientToDelete);
                Console.WriteLine("Client deleted from list.");
            }
            else
            {
                Console.WriteLine("Client Id not found. No changes made.");
            }
        }
        public void Delete(Client deleteClient)
        {
            Delete(deleteClient.Id);
        }

        public List<Client> Search(string query)
        {
            return Clients.Where(s => s.Name.ToUpper().Contains(query.ToUpper())).ToList();
        }

        public void AddClient(Client client)
        {
            Clients.Add(client);
        }

        public void EditClient(int id, DateTime OpenDate, DateTime ClosedDate,
            Boolean IsActive, String Name, String Notes)
        {
            var clientToUpdate = clients.FirstOrDefault(s => s.Id == id);
            if (clientToUpdate != null)
            {
                clientToUpdate.OpenDate = OpenDate;
                clientToUpdate.ClosedDate = ClosedDate;
                clientToUpdate.IsActive = IsActive;
                clientToUpdate.Name = Name;
                clientToUpdate.Notes = Notes;
            }
        }
    }
}
