
using Library.ClientProjectManagement.Models;
using Library.ClientProjectManagement.Services;
using MAUI.ClientProjectManagement.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MAUI.ClientProjectManagement.ViewModels
{
    public class ProjectViewModel
    {
        public Project Model { get; set; }

        public string Display
        {
            get
            {
                return Model.ToString();
            }
        }

        public ICommand DeleteProjectCommand { get; private set; }
        public void ExecuteDelete(int id)
        {
            ProjectService.Current.Delete(id);
        }

        public ICommand EditProjectCommand { get; private set; }
        public void ExecuteEdit(int id)
        {
            Shell.Current.GoToAsync($"//EditProject?projectId={id}");
        }

        public ICommand TimerCommand { get; private set; }
        public void ExecuteTimerCommand()
        {
            var window = new Window()
            {
                Width = 250,
                Height = 350,
                X = 0,
                Y = 0
            };
            var view = new TimerView(Model.Id);
            window.Page = view;
            Application.Current.OpenWindow(window);
        }

        public void SetUpCommands()
        {
            DeleteProjectCommand = new Command(
                (p) => ExecuteDelete((p as ProjectViewModel).Model.Id));

            EditProjectCommand = new Command(
                (p) => ExecuteEdit((p as ProjectViewModel).Model.Id));

            TimerCommand = new Command(ExecuteTimerCommand);
        }

        public ProjectViewModel()
        {
            Model = new Project();
            SetUpCommands();
        }

        public ProjectViewModel(Project model)
        {
            Model = model;
            SetUpCommands();
        }
    }
}
