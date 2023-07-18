using MAUI.ClientProjectManagement.ViewModels;

namespace MAUI.ClientProjectManagement.Views;

[QueryProperty(nameof(ProjectId), "projectId")]
public partial class EditProjectView : ContentPage
{
    public int ProjectId { get; set; }
	public EditProjectView()
	{
		InitializeComponent();
		//BindingContext = new EditProjectViewModel();
	}

    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ClientProject");
    }

    private void EnterClicked(object sender, EventArgs e)
    {
        (BindingContext as EditProjectViewModel).EditProject();
        Shell.Current.GoToAsync("//ClientProject");
    }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new EditProjectViewModel(ProjectId);
    }

}