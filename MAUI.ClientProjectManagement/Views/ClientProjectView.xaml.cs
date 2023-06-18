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
        if( (BindingContext as ClientProjectViewModel).SelectedClient != null)
        {
            (BindingContext as ClientProjectViewModel).PassSelectedClient();
            Shell.Current.GoToAsync("//EditClient");
        }
        
    }

    private void RefreshClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientProjectViewModel).Refresh();
    }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ClientProjectViewModel();
    }

    private void DeleteClientClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientProjectViewModel).DeleteClient();
    }

    private void DeleteProjectClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientProjectViewModel).DeleteProject();
    }

    private void AddProjectClicked(object sender, EventArgs e)
    {
        if ( (BindingContext as ClientProjectViewModel).SelectedClient != null)
        {
            (BindingContext as ClientProjectViewModel).PassSelectedClient();
            Shell.Current.GoToAsync("//AddProject");
        }
    }

    private void EditProjectClicked(object sender, EventArgs e)
    {
        if ( (BindingContext as ClientProjectViewModel).SelectedProject != null )
        {
            (BindingContext as ClientProjectViewModel).PassSelectedProject();
            Shell.Current.GoToAsync("//EditProject");
        }

    }

    private void FilterClicked(object sender, EventArgs e)
    {
        (BindingContext as ClientProjectViewModel).Filter();
    }
}