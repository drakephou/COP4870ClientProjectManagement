using MAUI.ClientProjectManagement.ViewModels;

namespace MAUI.ClientProjectManagement.Views;

public partial class AddProjectView : ContentPage
{
	public AddProjectView()
	{
		InitializeComponent();
		BindingContext = new AddProjectViewModel();


    }
    private void OnLeaving(object sender, NavigatedFromEventArgs e)    
    {    
        BindingContext = null;        
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new AddProjectViewModel();        
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