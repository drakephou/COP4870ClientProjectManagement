using MAUI.ClientProjectManagement.ViewModels;

namespace MAUI.ClientProjectManagement.Views;

public partial class EditTimeEntryView : ContentPage
{
	public EditTimeEntryView()
	{
		InitializeComponent();
		BindingContext = new EditTimeEntryViewModel();
	}
    private void BackButtonClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//EmployeeTime");
    }

    private void EnterClicked(object sender, EventArgs e)
    {
        (BindingContext as EditTimeEntryViewModel).EditTimeEntry();
        Shell.Current.GoToAsync("//EmployeeTime");
    }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
        BindingContext = null;
    }

    private void OnArriving(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new EditTimeEntryViewModel();
    }
}