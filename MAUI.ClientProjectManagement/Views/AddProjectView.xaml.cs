using MAUI.ClientProjectManagement.ViewModels;

namespace MAUI.ClientProjectManagement.Views;

[QueryProperty(nameof(ClientId), "clientId")]
public partial class AddProjectView : ContentPage
{
    public int ClientId { get; set; }
	public AddProjectView()
	{
		InitializeComponent();
    }
    private void OnLeaving(object sender, NavigatedFromEventArgs e)    
    {    
        BindingContext = null;        
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new AddProjectViewModel(ClientId);        
    }

    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ClientProject");
    }

    private void EnterClicked(object sender, EventArgs e)
    {
        (BindingContext as AddProjectViewModel).AddProject();
        Shell.Current.GoToAsync("//ClientProject");
    }
}