using MAUI.ClientProjectManagement.ViewModels;

namespace MAUI.ClientProjectManagement.Views;

public partial class ClientProjectView : ContentPage
{
	public ClientProjectView()
	{
		InitializeComponent();
		BindingContext = new ClientProjectViewModel();
	}

    private void BackButtonClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
    }

    private void AddClientClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//AddClient");
        //(BindingContext as ClientProjectViewModel).AddClientClicked();
    }

    private void EditClientClicked(object sender, EventArgs e)
    {
        /*
        if( (BindingContext as ClientProjectViewModel).SelectedClient != null)
        {
            
            (BindingContext as ClientProjectViewModel).PassSelectedClient();
            Shell.Current.GoToAsync("//EditClient");
        }
        */
        (BindingContext as ClientProjectViewModel).RefreshClients();
    }

    private void RefreshClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientProjectViewModel).Refresh();
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        //BindingContext = new ClientProjectViewModel();
        (BindingContext as ClientProjectViewModel).Refresh();
    }

    private void DeleteClientClicked(object sender, EventArgs e)
    {
        //(BindingContext as ClientProjectViewModel).DeleteClient();
        (BindingContext as ClientProjectViewModel).SelectedClient=null;
        (BindingContext as ClientProjectViewModel).RefreshClients();
    }

    private void DeleteProjectClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientProjectViewModel).Refresh();
    }

    private void AddProjectClicked(object sender, EventArgs e)
    {
        /*
        if ( (BindingContext as ClientProjectViewModel).SelectedClient != null)
        {
            (BindingContext as ClientProjectViewModel).PassSelectedClient();
            Shell.Current.GoToAsync($"//AddProject");
        }
        */
        (BindingContext as ClientProjectViewModel).RefreshProjects();
        
    }

    private void EditProjectClicked(object sender, EventArgs e)
    {
        /*
        if ( (BindingContext as ClientProjectViewModel).SelectedProject != null )
        {
            (BindingContext as ClientProjectViewModel).PassSelectedProject();
            Shell.Current.GoToAsync("//EditProject");
        }
        */

        (BindingContext as ClientProjectViewModel).RefreshProjects();
    }

    private void FilterClicked(object sender, EventArgs e)
    {
        //(BindingContext as ClientProjectViewModel).RefreshProjects();
        (BindingContext as ClientProjectViewModel).Filter();
    }

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientProjectViewModel).Search();
    }

    private void UnfilterClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientProjectViewModel).Unfilter();
    }
}