﻿using Library.ClientProjectManagement.Models;
using Library.ClientProjectManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MAUI.ClientProjectManagement.ViewModels
{
    public class ClientViewModel
    {
        public Client Model { get; set; }
        public string Display
        {
            get { return Model.ToString() ?? string.Empty; }
        }

        public ClientViewModel() 
        {
            Model = new Client();
        }

        public ICommand DeleteClientCommand { get; private set; }
        public void ExecuteDelete(int id)
        {
            if(!ProjectService.Current.clientIdExists(id))
            {
                ClientService.Current.Delete(id);
            }
        }

        
        public ICommand EditClientCommand { get; private set; }
        public void ExecuteEdit(int id)
        {
            Shell.Current.GoToAsync($"//EditClient?clientId={id}");
            //ClientService.Current.EditClient( c.Id, c.OpenDate, c.ClosedDate, c.IsActive, c.Name, c.Notes);
        }
        
        public ICommand AddProjectCommand { get; private set; }
        public void ExecuteAddProject(int id)
        {
            Shell.Current.GoToAsync($"//AddProject?clientId={id}");
        }

        public ICommand FilterProjectsCommand { get; private set; }
        public void ExecuteFilterProjects(int id)
        {
            ProjectService.Current.Filter(id);
        }

        public void SetupCommands()
        {
            DeleteClientCommand = new Command(
                (c) => ExecuteDelete((c as ClientViewModel).Model.Id));

            EditClientCommand = new Command(
                (c) => ExecuteEdit((c as ClientViewModel).Model.Id));

            AddProjectCommand = new Command(
                (c) => ExecuteAddProject((c as ClientViewModel).Model.Id));

            FilterProjectsCommand = new Command(
                (c) => ExecuteFilterProjects((c as ClientViewModel).Model.Id));
        }

        public ClientViewModel(Client client)
        {
            Model = client;
            SetupCommands();
        }
    }
}