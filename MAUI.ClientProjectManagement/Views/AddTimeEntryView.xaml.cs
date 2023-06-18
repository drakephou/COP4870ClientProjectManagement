using MAUI.ClientProjectManagement.ViewModels;

namespace MAUI.ClientProjectManagement.Views;

public partial class AddTimeEntryView : ContentPage
{
	public AddTimeEntryView()
	{
		InitializeComponent();
		BindingContext = new AddTimeEntryViewModel();
	}

    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//EmployeeTime");
    }

    private void EnterClicked(object sender, EventArgs e)
    {
        (BindingContext as AddTimeEntryViewModel).AddTimeEntry();
        Shell.Current.GoToAsync("//EmployeeTime");
    }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new AddTimeEntryViewModel();
    }
}