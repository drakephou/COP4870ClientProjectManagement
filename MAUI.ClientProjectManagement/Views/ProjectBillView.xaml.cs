using MAUI.ClientProjectManagement.ViewModels;

namespace MAUI.ClientProjectManagement.Views;

[QueryProperty(nameof(ProjectId), "projectId")]
public partial class ProjectBillView : ContentPage
{
	public int ProjectId { get; set; }
	public ProjectBillView()
	{
		InitializeComponent();
	}

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new ProjectBillViewModel(ProjectId);
    }

    private void GenerateBillClicked(object sender, EventArgs e)
    {
        (BindingContext as ProjectBillViewModel).GenerateBill();
    }

    private void BackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//ClientProject");
    }
}