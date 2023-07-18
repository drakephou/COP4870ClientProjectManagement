using Library.ClientProjectManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ClientProjectManagement.Services
{
    public class ProjectService
    {
        private static ProjectService? instance;

        public static ProjectService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProjectService();
                }
                return instance;
            }
        }

        private List<Project> projects;
        private Project? selectedProject;
        private ProjectService()
        {
            projects = new List<Project>();
            projects.Add(new Project
            {
                Id = 1,
                OpenDate = DateTime.Now,
                ClosedDate = DateTime.Now,
                IsActive = false,
                ShortName = "Test1",
                LongName = "Test1",
                ClientId = 1
            });
            projects.Add(new Project
            {
                Id = 2,
                OpenDate = DateTime.Now,
                ClosedDate = DateTime.Now,
                IsActive = false,
                ShortName = "Test2",
                LongName = "Test2",
                ClientId = 2
            });
        }

        public List<Project> Projects 
        {   
            get 
            {
                return projects;
            }
        }

        public Project? SelectedProject
        {
            get
            {
                return selectedProject;
            }
            set { selectedProject = value; }
        }

        public Project? GetProject(int id)
        {
            return projects.FirstOrDefault(p => p.Id == id);
        }

        public bool clientIdExists(int clientId)
        {
            bool found = false;
            if( (projects.FirstOrDefault(e => e.ClientId == clientId)) != null )
            {
                found = true;
            }
            return found;
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

            Console.WriteLine("ShortName: ");
            String ShortName = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("LongName: ");
            String LongName = Console.ReadLine() ?? string.Empty;

            formatCheck = true;
            int ClientId = -1;
            while (formatCheck)
            {
                Console.WriteLine("ClientId: ");
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

            projects.Add(new Project
            {
                Id = Id,
                OpenDate = OpenDate,
                ClosedDate = ClosedDate,
                IsActive = IsActive,
                ShortName = ShortName,
                LongName = LongName,
                ClientId = ClientId
            });
        }

        public void Read()
        {
            Console.WriteLine("Listing all Projects");
            projects.ForEach(Console.WriteLine);
        }


        public void Delete(int deleteChoice)
        {
            var projectToDelete = projects.FirstOrDefault(s => s.Id == deleteChoice);
            if (projectToDelete != null)
            {
                projects.Remove(projectToDelete);
                Console.WriteLine("Project deleted from list.");
            }
            else
            {
                Console.WriteLine("Project Id not found. No changes made.");
            }
        }
        public void Delete(Project deleteProject)
        {
            Delete(deleteProject.Id);
        }

        public void AddProject(Project project)
        {
            Projects.Add(project);
        }

        public void EditProject(int id, DateTime OpenDate, DateTime ClosedDate,
            Boolean IsActive, String ShortName, String LongName, int clientId)
        {
            var projectToUpdate = projects.FirstOrDefault(s => s.Id == id && s.ClientId == clientId);
            if (projectToUpdate != null)
            {
                projectToUpdate.OpenDate = OpenDate;
                projectToUpdate.ClosedDate = ClosedDate;
                projectToUpdate.IsActive = IsActive;
                projectToUpdate.ShortName = ShortName;
                projectToUpdate.LongName = LongName;
            }
        }

        private int filterId = -1;
        public int FilterId
        {
            get
            {
                return filterId;
            }
            set
            {
                filterId = value;
            }
        }

        public void Filter(int id)
        {
            FilterId = id;
        }
        public List<Project> Filter()
        {
            if(filterId >= 0)
                return Projects.Where(s => s.ClientId == FilterId).ToList();
            else
                return Projects;
        }
    }


}
